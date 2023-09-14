using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

[ApiController]
[Route("api/genres")]
public class GenreController : ControllerBase
{
    private readonly TmdbService _tmdbService;

    public GenreController(TmdbService tmdbService)
    {
        _tmdbService = tmdbService;
    }

    [HttpGet("{genreId}/suggestions")]
    public async Task<IActionResult> GetMovieSuggestions(int genreId)
    {
        try
        {
            var recommendations = await _tmdbService.GetMovieRecommendationsAsync(genreId.ToString());
            return Ok(recommendations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while fetching movie recommendations: {ex.Message}");
        }
    }
}

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
            // Deserialize JSON into C#
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
