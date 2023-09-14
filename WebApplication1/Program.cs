using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging; // Added using statement for ILogger
using WebApplication1App.Data;
using WebApplication1App.Data.WebApplication1App.Data;
using System;
using System.Collections.Generic; // Added using statement for List
using Microsoft.OpenApi.Models;

namespace WebApplication1App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Read configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            // Add services to the container.
            builder.Services.AddDbContext<WebApplication1AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddHttpClient<TmdbService>();
            builder.Services.AddScoped<TmdbService>();
            builder.Services.AddSingleton(configuration.GetSection("ApiKey").Value);

            builder.Services.AddControllers();


            // Swagger configuration
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
            });

            var app = builder.Build();

            // Configure middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
                });
            }
            else
            {
                // Add production middleware as needed
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            // Initialize the database and seed data
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<WebApplication1AppDbContext>();
                var logger = services.GetRequiredService<ILogger<Program>>(); // Get ILogger

                try
                {
                    dbContext.Database.Migrate();

                    // Seed the database with sample data
                    SeedData(dbContext);

                    // Log successful database initialization
                    logger.LogInformation("Database initialized and seeded successfully.");
                }
                catch (Exception ex)
                {
                    // Log any exceptions that occur during migration or seeding
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            app.Run();
        }

        private static void SeedData(WebApplication1AppDbContext context)
        {
            var persons = new List<Person>
            {
                new Person { Name = "John Doe" },
                new Person { Name = "Jane Smith" },
            };

            var genres = new List<Genre>
            {
                new Genre { Name = "Action" },
                new Genre { Name = "Comedy" },
            };

            context.People.AddRange(persons);
            context.Genres.AddRange(genres);

            context.SaveChanges();
        }
    }
}
