using Microsoft.EntityFrameworkCore;
using WebApplication1App.Data; // Change the namespace here

namespace WebApplication1App // Change the namespace here
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<WebApplication1App.Data.WebApplication1App>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();


            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddControllers();
            //using Swagger 
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //configure Swagger HTTPS
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
