using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class MovieLinkRepository : IMovieLinkRepository
    {
        private readonly DbContext _context;

        public MovieLinkRepository(DbContext context)
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
            return _context.Set<MovieLink>().Where(ml => ml.PersonId == personId).ToList(); //implementation 
        }
    }
}
