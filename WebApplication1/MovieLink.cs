using System;

namespace WebApplication1App.Data
{
    public class MovieLink
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int PersonId { get; set; } 
        public int GenreId { get; set; }  
        

        
        public Person Person { get; set; }
        public Genre Genre { get; set; }
    }
}
