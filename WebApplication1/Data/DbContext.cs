using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication1.Data
{
    public class WebApplication1 : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieLink> MovieLinks { get; set; }

        public WebApplication1(DbContextOptions<DbContext> options) : base(options)
        {
        }

        .
    }
}
