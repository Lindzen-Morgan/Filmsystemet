using Microsoft.EntityFrameworkCore;

namespace WebApplication1App.Data;

public interface IMovieLinkRepository
{
    IEnumerable<MovieLink> GetAllMovieLinks();
    MovieLink GetMovieLinkById(int id);
    void AddMovieLink(MovieLink movieLink);
    void UpdateMovieLink(MovieLink movieLink);
    void DeleteMovieLink(int id);
    IEnumerable<MovieLink> GetMovieLinksForPerson(int personId);//for fetching link to person
    MovieLinkRating GetMovieLinkRating(int personId, int movieLinkId);
    void AddMovieLinkRating(int personId, int movieLinkId, MovieLinkRating rating);


}

