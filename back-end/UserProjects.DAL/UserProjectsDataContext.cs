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

    public sealed class UserProjectsDataContext : DbContext, IDataContext
    {
        private readonly ILogger<UserProjectsDataContext> _logger;
        public DbSet<User> User { get; set; }

        // public DbSet<Gender> Gender { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<User>().HasIndex(t => t.Email).IsUnique();
            // modelBuilder.Entity<User>().HasIndex(i => i.UserName).IsUnique();

            // modelBuilder.Entity<User>().Property(i => i.UserNameUpdatedCount).IsRequired().HasDefaultValue(0);

            // base.OnModelCreating(modelBuilder);

            // MoveTableToAuthSchema<User>(modelBuilder, "User");

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

        // private void MoveTableToAuthSchema<TTable>(ModelBuilder modelBuilder, string name) where TTable : class
        // {
        //     modelBuilder
        //         .Entity<TTable>()
        //         .ToTable(name, "auth");
        // }

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

           // await SeedAsync();
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

       
            // if (!Gender.Any())
            // {
            //     var defaultGenders = new List<Gender> {
            //         new Gender { Name = "male"},
            //         new Gender { Name = "female"},
            //         new Gender { Name = Constants.DEFAULT_GENDER }
            //     };
            //     await Gender.AddRangeAsync(defaultGenders);
            //     SaveChanges();
            // }

            // if (!Roles.Any()) 
            // {
            //     var defaultRoles = new List<IdentityRole>
            //     {
            //         new IdentityRole { Name = Constants.USER_ROLE_FAN, NormalizedName = Constants.USER_ROLE_FAN.ToUpper() },
            //         new IdentityRole { Name = Constants.USER_ROLE_ARTIST, NormalizedName = Constants.USER_ROLE_ARTIST.ToUpper() },
            //         new IdentityRole { Name = Constants.USER_ROLE_MANAGER, NormalizedName = Constants.USER_ROLE_MANAGER.ToUpper() }
            //     };
            //     await Roles.AddRangeAsync(defaultRoles);
            //     SaveChanges();
            // }
        // }
    }
}
