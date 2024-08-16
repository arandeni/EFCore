using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace StudentManagement.Models
{
    public class StudentManagementContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<CourseStudent> CourseStudents => Set<CourseStudent>();

        #region 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder
              .Entity<CourseStudent>()
              .HasOne(e => e.Student)
              .WithMany(e => e.Courses)
              .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
             .Entity<CourseStudent>()
             .HasOne(e => e.Course)
             .WithMany(e => e.Students)
             .OnDelete(DeleteBehavior.ClientCascade);

            /* modelBuilder.Entity<Student>()
                 .HasMany(e => e.Courses)
                 .WithMany(e => e.Students)
                 .UsingEntity(
                     "CourseStudent",
                     l => l.HasOne(typeof(Course)).WithMany().HasForeignKey("CourseId").HasPrincipalKey(nameof(Course.Id)),
                     r => r.HasOne(typeof(Student)).WithMany().HasForeignKey("StudentId").HasPrincipalKey(nameof(Student.Id)),
                     j => j.HasKey("StudentId", "CourseId"));*/
        }
        #endregion
    }
}
