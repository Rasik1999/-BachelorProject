using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data
            modelBuilder.Entity<KindOfProject>().HasData(new KindOfProject { KindOfProjectId = 1, Name = "TestName1" });
            modelBuilder.Entity<KindOfProject>().HasData(new KindOfProject { KindOfProjectId = 2, Name = "TestName2" });
            modelBuilder.Entity<KindOfProject>().HasData(new KindOfProject { KindOfProjectId = 3, Name = "TestName3" });

            modelBuilder.Entity<User>().HasData(new User { UserId = 1, LastName = "Yagon", FirstName = "Don" });
            modelBuilder.Entity<User>().HasData(new User { UserId = 2, LastName = "Yasha", FirstName = "Lava" });

            modelBuilder.Entity<Project>().HasData(
                new Project 
                {
                    ProjectId = 1,
                    KindOfProjectId = 1,
                    UserId = 1,
                    Title = "Title1",
                    Description = "Description1"
                });

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    ProjectId = 2,
                    KindOfProjectId = 2,
                    UserId = 2,
                    Title = "Title2",
                    Description = "Description2"
                });
        }
    }
}
