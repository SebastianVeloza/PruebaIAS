using Infrastructure._Persistence;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Extensions
{
    public static class MigrationExtension
    {
        public static void ApplyMigration(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbcontext= scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbcontext.Database.Migrate();
        }
    }
}
