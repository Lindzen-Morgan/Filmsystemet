namespace WebApplication1
{
   public class person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<Genre> FavoriteGenres { get; set; } = new List<Genre>();
        public List<MovieLink> MovieLinks { get; set; } = new List<MovieLink>();
    }
}
