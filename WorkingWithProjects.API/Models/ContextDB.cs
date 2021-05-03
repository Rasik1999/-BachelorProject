﻿using Microsoft.EntityFrameworkCore;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Models
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Progress> Progresses { get; set; }
        public DbSet<KindOfProject> KindsOfProject { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data
            modelBuilder.Entity<Role>().HasData(new Role { RoleId = 1, Name = "Student" });
            modelBuilder.Entity<Role>().HasData(new Role { RoleId = 2, Name = "Administrator" });

            modelBuilder.Entity<KindOfProject>().HasData(new KindOfProject { KindOfProjectId = 1, Name = "TestName1"});
            modelBuilder.Entity<KindOfProject>().HasData(new KindOfProject { KindOfProjectId = 2, Name = "TestName2"});
            modelBuilder.Entity<KindOfProject>().HasData(new KindOfProject { KindOfProjectId = 3, Name = "TestName3" });

            modelBuilder.Entity<User>().HasData(new User { UserId = 1, LastName = "Yagon", FirstName = "Don", RolesId = 1 });
            modelBuilder.Entity<User>().HasData(new User { UserId = 2, LastName = "Yasha", FirstName = "Lava", RolesId = 2 });

            modelBuilder.Entity<Hashtag>().HasData(new Hashtag { HashtagId = 1, Name = "HashtagName1" });
            modelBuilder.Entity<Hashtag>().HasData(new Hashtag { HashtagId = 2, Name = "HashtagName2" });
            modelBuilder.Entity<Hashtag>().HasData(new Hashtag { HashtagId = 3, Name = "HashtagName3" });

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    ProjectId = 1,
                    KindOfProjectId = 1,
                    UserId = 1,
                    Title = "Title1",
                    Description = "Description1",
                    HashtagIds = "1,2"
                });

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    ProjectId = 2,
                    KindOfProjectId = 2,
                    UserId = 2,
                    Title = "Title2",
                    Description = "Description2",
                    HashtagIds = "2,3"
                });

            modelBuilder.Entity<Progress>().HasData(
                new Progress
                {
                    ProgressId = 1,
                    ProjectId = 1,
                    DesiredValue = 5430,
                    Value = 4000
                });

            modelBuilder.Entity<Progress>().HasData(
                new Progress
                {
                    ProgressId = 2,
                    ProjectId = 2,
                    DesiredValue = 6000,
                    Value = 2000
                });
        }
    }
}
