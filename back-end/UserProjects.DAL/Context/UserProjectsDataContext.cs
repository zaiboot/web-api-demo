namespace UserProjects.DAL
{
    using Common.Results;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Microsoft.EntityFrameworkCore.Migrations;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Microsoft.Extensions.Logging;
    using UserProjects.DAL.Context;
    using System;

    public sealed class UserProjectsDataContext : DbContext, IDataContext
    {
        private readonly ILogger<UserProjectsDataContext> _logger;
        public DbSet<User> User { get; set; }
        public DbSet<Project> Project { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserProject>()
            .HasKey(up => new { up.UserId, up.ProjectId });

            modelBuilder.Entity<UserProject>()
            .HasOne(up => up.User)
            .WithMany(u => u.UserProjects)
            .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserProject>()
            .HasOne(up => up.Project)
            .WithMany(p => p.UserProjects)
            .HasForeignKey(up => up.ProjectId);
        }

        public UserProjectsDataContext(DbContextOptions options, ILogger<UserProjectsDataContext> logger) : base(options)
        {
            _logger = logger;
        }

        public async Task<Response> SaveAsync()
        {
            var response = ResponseCreator.CreateNegativeResponse();

            if (await SaveChangesAsync() > 0)
            {
                response.Result = true;
            }

            return response;
        }

        public async Task MigrateAsync()
        {
            if (!AllMigrationsApplied())
            {
                try
                {
                    await Database.MigrateAsync();
                }
                catch (SqlException ex)
                {
                    _logger.LogError(ex, "Error when applying migrations");
                    throw;
                }
            }

            await SeedAsync();
        }

        private async Task SeedAsync()
        {
            if (!User.Any())
            {
                var users = new List<User>();

                for (int userCount = 0; userCount < 10; userCount++)
                {
                    users.Add(new User { FirstName = "Test -" + userCount, LastName = "Madrigal " + userCount });
                }
                await User.AddRangeAsync(users);

            }

            if (!Project.Any())
            {
                var projects = new List<Project>();

                for (int projectIndex = 0; projectIndex < 100; projectIndex++)
                {
                    projects.Add(new Project { StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddDays(projectIndex), Credits = projectIndex + 1 });
                }
                await Project.AddRangeAsync(projects);

            }
            SaveChanges();

            var usersWithProjects = await User.Take(5).OrderBy(u => u.Id).ToListAsync();

            var projectCount = 1;
            foreach (var u in usersWithProjects)
            {
                if (!u.UserProjects.Any())
                {
                    var projects = Project.Skip(projectCount).Take(projectCount).Select(p =>
                       new UserProject
                       {
                           UserId = u.Id,
                           ProjectId = p.Id
                       }

                    );

                    u.UserProjects.AddRange(projects);
                }
                projectCount++;
            }


        }

        private bool AllMigrationsApplied()
        {
            var applied = this.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = this.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

    }
}
