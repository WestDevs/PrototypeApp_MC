using Microsoft.EntityFrameworkCore;
using WEST.Api.Entities;

namespace WEST.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) {}
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Learner> Learners { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<LearnerCourse> LearnerCourses { get; set; }
        public DbSet<LearnerGroup> LearnerGroup { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().ToTable("User");
            modelBuilder.Entity<Organisation>().ToTable("Organisation");
            modelBuilder.Entity<Learner>().ToTable("Learner");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<LearnerCourse>().ToTable("LearnerCourse");
            modelBuilder.Entity<LearnerGroup>().ToTable("LearnerGroup");
            modelBuilder.Entity<Group>().ToTable("Group");


            modelBuilder.Entity<Learner>()
                .HasKey(l => new { l.LearnerId });
            modelBuilder.Entity<LearnerCourse>()
                .HasKey(lc => new { lc.LearnerId, lc.CourseId });
            modelBuilder.Entity<LearnerGroup>()
                .HasKey(lg => new { lg.LearnerId, lg.GroupId });
        }
    }
}