using System.Collections.Generic;

namespace WebApplication1App.Data
{
   public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();

        public List<MovieLink> MovieLinks { get; set; } = new List<MovieLink>();
        public ICollection<Genre> GenresInterested { get; set; }
    }
}
