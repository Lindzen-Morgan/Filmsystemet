using Microsoft.EntityFrameworkCore;
using WebApplication1App.Data; 


namespace WebApplication1App 
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
