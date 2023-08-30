namespace WebApplication1.Data
{
    public interface IMovieLinkRepository
    {
        IEnumerable<MovieLink> GetAllMovieLinks();
        MovieLink GetMovieLinkById(int id);
        void AddMovieLink(MovieLink movieLink);
        void UpdateMovieLink(MovieLink movieLink);
        void DeleteMovieLink(int id);
    }
}
