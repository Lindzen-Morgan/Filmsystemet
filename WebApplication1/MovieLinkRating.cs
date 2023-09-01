using System;

namespace WebApplication1App.Data
{
    public class MovieLinkRating
    {
        public int Id { get; set; }
        public int MovieLinkId { get; set; }
        public int Rating { get; set; }
        public int PersonId { get; set; }
        
        public MovieLink MovieLink { get; set; }
    }
}
