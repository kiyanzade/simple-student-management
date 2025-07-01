using Microsoft.EntityFrameworkCore;
using StudentTask.Database.Contexts;

namespace StudentTask.Api
{
    public static class ConfigureWebApplication
    {
        public static void UseSwaggerAndUi(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        public static void InitializeDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<StudentContext>();
            db.Database.Migrate();
        }

    }
}
