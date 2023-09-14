using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1App.Data;

namespace WebApplication1App.Data
{
    public class WebApplication1AppDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieLink> MovieLinks { get; set; }
        public DbSet<MovieLinkRating> MovieLinkRatings { get; set; }

        public WebApplication1AppDbContext(DbContextOptions<WebApplication1AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship between Genre and Person
            modelBuilder.Entity<Genre>()
                .HasOne(g => g.Person)
                .WithMany(p => p.GenresInterested) 
                .HasForeignKey(g => g.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            

            base.OnModelCreating(modelBuilder);
        }



    }
}
