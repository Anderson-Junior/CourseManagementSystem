using CourseManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        {
        }
    }
}
