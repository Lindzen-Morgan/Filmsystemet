using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace WebApplication1App.Data
{
    public class GenreRepository : IGenreRepository
    {
        private readonly WebApplication1App _context;

        public GenreRepository(WebApplication1App.Data.WebApplication1App context)
        {
            _context = context;
        }


        public IEnumerable<Genre> GetAllGenres()
        {
            return _context.Set<Genre>().ToList();
        }

        public Genre GetGenreById(int id)
        {
            return _context.Set<Genre>().FirstOrDefault(g => g.Id == id);
        }

        public void AddGenre(Genre genre)
        {
            _context.Set<Genre>().Add(genre);
            _context.SaveChanges();
        }

        public void UpdateGenre(Genre genre)
        {
            _context.Set<Genre>().Update(genre);
            _context.SaveChanges();
        }

        public void DeleteGenre(int id)
        {
            var genre = _context.Set<Genre>().FirstOrDefault(g => g.Id == id);
            if (genre != null)
            {
                _context.Set<Genre>().Remove(genre);
                _context.SaveChanges();
            }
        }
        public IEnumerable<Genre> GetGenresForPerson(int personId) //linking person to genre
        {
            return _context.Genres.Where(g => g.PersonId == personId).ToList();
        }
        public void LinkPersonToGenre(int personId, int genreId)
        {
            var person = _context.People.Include(p => p.Genres).FirstOrDefault(p => p.Id == personId);
            var genre = _context.Genres.FirstOrDefault(g => g.Id == genreId);

            if (person != null && genre != null)
            {
                person.Genres.Add(genre);
                _context.SaveChanges();
            }
        }
    }
}
