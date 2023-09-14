using WebApplication1App.Data;

namespace WebApplication1.Data
{
    public static class DataSeeder
    {
        public static void SeedData(WebApplication1AppDbContext context)
        {
            
            var person1 = new Person { Name = "John Doe" };
            var person2 = new Person { Name = "Jane Smith" };
           

            context.People.AddRange(person1, person2);
            context.SaveChanges();

            
            var genre1 = new Genre { Name = "Action" };
            var genre2 = new Genre { Name = "Comedy" };
            

            context.Genres.AddRange(genre1, genre2);
            context.SaveChanges();

            
            person1.GenresInterested.Add(genre1);
            person2.GenresInterested.Add(genre2);

            context.SaveChanges();
        }
    }

}
