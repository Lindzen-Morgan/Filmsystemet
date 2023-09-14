using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

       
        public DbSet<Person> People { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieLinkRating> MovieLinkRatings { get; set; }
        public DbSet<MovieLink> MovieLinks { get; set; }
        public DbSet<Rating> Ratings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        public ApplicationDbContext(DbContextOptions<WebApplication1AppDbContext> options)
       : base(options)
        {
        }
    }
}
