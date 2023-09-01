using System.Collections.Generic;


namespace WebApplication1App.Data
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAllGenres();
        Genre GetGenreById(int id);
        void AddGenre(Genre genre);
        void UpdateGenre(Genre genre);
        void DeleteGenre(int id);
        IEnumerable<Genre> GetGenresForPerson(int personId);

    }
}
