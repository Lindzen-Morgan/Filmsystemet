using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1App.Data;

namespace WebApplication1App.Data
{
    public class WebApplication1App : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieLink> MovieLinks { get; set; }
        public DbSet<MovieLinkRating> MovieLinkRatings { get; set; } // Add this DbSet

        public WebApplication1App(DbContextOptions<WebApplication1App> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // RElationship between person and Genre
            modelBuilder.Entity<Person>()
                .HasMany(p => p.GenresInterested)
                .WithMany(g => g.PeopleInterested)
                .UsingEntity(j => j.ToTable("PersonGenres"));

            

            base.OnModelCreating(modelBuilder);
        }


    }
}
