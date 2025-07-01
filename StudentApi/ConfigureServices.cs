using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StudentTask.Database.Contexts;
using StudentTask.Database.Entities;
using StudentTask.Services.StudentService;
using StudentTask.Services.StudentService.Dto;

namespace StudentTask.Api
{
    public static class ConfigureServices
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StudentContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.CreateMap<StudentModel, GetStudentDto>();
                config.CreateMap<StudentModel, EditStudentDto>();
                config.CreateMap<AddStudentDto, StudentModel>();

            });
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            // fix bug swagger
            services.AddSwaggerGen(ops => ops.MapType<DateOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "date"
            }));
        }

    }
}
