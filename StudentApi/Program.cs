
namespace StudentTask.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext(builder.Configuration);
            builder.Services.AddServices();
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper();
            builder.Services.AddMemoryCache();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwagger();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerAndUi();
            }
            app.UseHttpsRedirection();
            app.InitializeDatabase();
            app.MapControllers();
            app.Run();
        }
    }
}
