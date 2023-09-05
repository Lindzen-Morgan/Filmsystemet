using Microsoft.EntityFrameworkCore;

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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity relationships and constraints here
            // For example, you can define primary keys, foreign keys, etc.
        }
    }
}
