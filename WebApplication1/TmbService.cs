using System;
using System.Net.Http;
using System.Threading.Tasks;

public class TmdbService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public TmdbService(HttpClient httpClient, string apiKey)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
    }

    public async Task<TmdbMovieRecommendations> GetMovieRecommendationsAsync(string genreId)
    {
        // Build URL for TMDB request
        var apiUrl = $"https://api.themoviedb.org/3/discover/movie?api_key={_apiKey}&with_genres={genreId}";

        // Send a get request to TMDB API
        var response = await _httpClient.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
           //Json into c#
            var content = await response.Content.ReadAsAsync<TmdbMovieRecommendations>();
            return content;
        }
        
        else
        {
            // Handle API error responses
            throw new Exception($"Failed to retrieve movie recommendations. Status code: {response.StatusCode}");
        }
    }
}
