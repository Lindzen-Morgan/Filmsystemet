using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace WebApplication1.Data
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DbContext _context;

        public GenreRepository(DbContext context)
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
    }
}
