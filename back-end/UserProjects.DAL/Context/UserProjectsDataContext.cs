namespace UserProjects.DAL.Context
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

    using System;

    public sealed class UserProjectsDataContext : DbContext
    {
        private readonly ILogger<UserProjectsDataContext> _logger;
        public DbSet<User> User { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<UserProject> UserProject { get; set; }
        

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserProject>()
            .HasKey(up => new {up.ProjectId, up.UserId});


    }
        public UserProjectsDataContext(DbContextOptions options, ILogger<UserProjectsDataContext> logger) : base(options)
        {
            _logger = logger;
        }

    }
}
