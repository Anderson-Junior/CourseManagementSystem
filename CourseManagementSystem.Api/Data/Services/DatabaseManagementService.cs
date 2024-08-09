using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Api.Data.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialization(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider.GetService<AppDbContext>();

                serviceDb.Database.Migrate();
            }
        }
    }
}
