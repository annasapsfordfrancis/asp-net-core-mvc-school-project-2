using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace SchoolProject.Models
{
    public class SchoolProjectDbContext : DbContext
    {
        public SchoolProjectDbContext(DbContextOptions<SchoolProjectDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Course
            modelBuilder.Entity<Course>().Property(a => a.CourseName)
                .IsRequired();

            modelBuilder.Entity<Course>().Property(a => a.CourseDescription)
                .IsRequired();

            // School
            modelBuilder.Entity<School>().Property(a => a.SchoolName)
                .IsRequired();

            // User
            modelBuilder.Entity<User>().HasOne(a => a.UserType)
                .WithMany(a => a.Users)
                .HasForeignKey(a => a.UserTypeId);

            modelBuilder.Entity<User>().HasOne<School>(a => a.School)
                .WithMany(a => a.Users)
                .HasForeignKey(a => a.SchoolId);

            modelBuilder.Entity<User>().Property(a => a.FirstName)
                .IsRequired();

            modelBuilder.Entity<User>().Property(a => a.LastName)
                .IsRequired();

            // UserCourse
            modelBuilder.Entity<UserCourse>().HasKey(us => new { us.UserId, us.CourseId});

            modelBuilder.Entity<UserCourse>().HasOne(a => a.User)
                .WithMany(a => a.UserCourses)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<UserCourse>().HasOne(a => a.Course)
                .WithMany(a => a.UserCourses)
                .HasForeignKey(a => a.CourseId);

            // UserType
            modelBuilder.Entity<UserType>().Property(a => a.UserTypeName)
                .IsRequired();

            // Seed data
            // School
            modelBuilder.Entity<School>().HasData(
                new { SchoolId = 1, SchoolName = "Hogwarts" });

            // Course
            modelBuilder.Entity<Course>().HasData(
                new { CourseId = 1, CourseName = "Potions 1a", CourseDescription = "Introductory potions." },
                new { CourseId = 2, CourseName = "Defence Against the Dark Arts 1a", CourseDescription = "Introductory defensive magic." });

            // UserType
            modelBuilder.Entity<UserType>().HasData(
                new { UserTypeId = 1, UserTypeName = "Teacher" },
                new { UserTypeId = 2, UserTypeName = "Pupil" });
        }

        public DbSet<User>? User { get; set; }
        public DbSet<UserType>? UserType { get; set; }
        public DbSet<School>? School { get; set; }
        public DbSet<Course>? Course { get; set; }
        public DbSet<UserCourse>? UserCourse { get; set; }
    }
}