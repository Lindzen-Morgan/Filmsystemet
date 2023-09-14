using Microsoft.EntityFrameworkCore;

namespace WebApplication1App.Data
{
    public class MovieLinkRepository : IMovieLinkRepository
    {
        private readonly WebApplication1AppDbContext _context; 

        public MovieLinkRepository(WebApplication1AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MovieLink> GetAllMovieLinks()
        {
            return _context.Set<MovieLink>().ToList();
        }

        public MovieLink GetMovieLinkById(int id)
        {
            return _context.Set<MovieLink>().FirstOrDefault(ml => ml.Id == id);
        }

        public void AddMovieLink(MovieLink movieLink)
        {
            _context.Set<MovieLink>().Add(movieLink);
            _context.SaveChanges();
        }

        public void UpdateMovieLink(MovieLink movieLink)
        {
            _context.Set<MovieLink>().Update(movieLink);
            _context.SaveChanges();
        }

        public void DeleteMovieLink(int id)
        {
            var movieLink = _context.Set<MovieLink>().FirstOrDefault(ml => ml.Id == id);
            if (movieLink != null)
            {
                _context.Set<MovieLink>().Remove(movieLink);
                _context.SaveChanges();
            }
        }
        public IEnumerable<MovieLink> GetMovieLinksForPerson(int personId)
        {
            return _context.MovieLinks.Where(ml => ml.PersonId == personId).ToList();
        }
        public MovieLinkRating GetMovieLinkRating(int personId, int movieLinkId)
        {
            return _context.MovieLinkRatings.FirstOrDefault(r => r.PersonId == personId && r.MovieLinkId == movieLinkId);
        }

        public void AddMovieLinkRating(int personId, int movieLinkId, MovieLinkRating rating)
        {
            rating.PersonId = personId;
            rating.MovieLinkId = movieLinkId;
            _context.MovieLinkRatings.Add(rating);
            _context.SaveChanges();
        }

    }
}
