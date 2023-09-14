namespace WebApplication1.Data
{
    public class Rating
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int PersonId { get; set; }
        public int RatingValue { get; set; }
    }
}
