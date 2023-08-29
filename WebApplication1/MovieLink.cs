namespace WebApplication1
{
    public class MovieLink
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public int GenreId { get; set; }
        public int PersonId { get; set; }
        public int Rating { get; set; } // You can use a different data type for rating

        public Genre Genre { get; set; }
        public Person Person { get; set; }
    }
}
