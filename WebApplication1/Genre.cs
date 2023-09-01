using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1App.Data
{
    public class Genre
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Navigation property to connect with Person
        public List<Person> PeopleInterested { get; set; } = new List<Person>();
        public List<MovieLink> MovieLinks { get; set; } = new List<MovieLink>();
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
}
