using Microsoft.EntityFrameworkCore;
using Portfolio_API.Data;
using Portfolio_API.Repository;
using Portfolio_API.Repository.Repository_Interface;

namespace Portfolio_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<PorfolioContext>(option => option.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));

            builder.Services.AddScoped<IUser, UserRepository>();
            builder.Services.AddScoped<IAbout, AboutRepository>();
            builder.Services.AddScoped<IEducation, EducationRepository>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}