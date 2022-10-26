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
            modelBuilder.Entity<User>().HasOne(a => a.UserType)
                .WithMany(a => a.Users)
                .HasForeignKey(a => a.UserTypeId);

            modelBuilder.Entity<UserCourse>().HasKey(us => new { us.UserId, us.CourseId});

            modelBuilder.Entity<UserCourse>().HasOne(a => a.User)
                .WithMany(a => a.UserCourses)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<UserCourse>().HasOne(a => a.Course)
                .WithMany(a => a.UserCourses)
                .HasForeignKey(a => a.CourseId);
        }

        public DbSet<User>? User { get; set; }
        public DbSet<UserType>? UserType { get; set; }
        public DbSet<School>? School { get; set; }
        public DbSet<Course>? Course { get; set; }
        public DbSet<UserCourse>? UserCourse { get; set; }
    }
}