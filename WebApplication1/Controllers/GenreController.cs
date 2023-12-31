﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1App.Data;

namespace WebApplication1App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;
        private readonly TmdbService _tmdbService; // Inject TmdbService

        public GenreController(IGenreRepository genreRepository, TmdbService tmdbService)
        {
            _genreRepository = genreRepository;
            _tmdbService = tmdbService; // Initialize TmdbService
        }
        //get all genres
        [HttpGet]
        public IActionResult GetAllGenres()
        {
            var genres = _genreRepository.GetAllGenres();
            return Ok(genres);
        }
       
        //Get genre ID
        [HttpGet("{id}")]
        public IActionResult GetGenreById(int id)
        {
            var genre = _genreRepository.GetGenreById(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }
        //Post genres
        [HttpPost]
        public IActionResult AddGenre([FromBody] Genre genre)
        {
            if (genre == null)
            {
                return BadRequest();
            }

            _genreRepository.AddGenre(genre);
            return CreatedAtAction(nameof(GetGenreById), new { id = genre.Id }, genre);
        }
        //update per id
        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] Genre genre)
        {
            if (genre == null || id != genre.Id)
            {
                return BadRequest();
            }

            _genreRepository.UpdateGenre(genre);
            return NoContent();
        }
        //delete genre by id
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            var genre = _genreRepository.GetGenreById(id);
            if (genre == null)
            {
                return NotFound();
            }

            _genreRepository.DeleteGenre(id);
            return NoContent();
        }

        [HttpGet("~/api/person/{personId}/genres")] // Get genres for a person
        public IActionResult GetGenresForPerson(int personId)
        {
            var genres = _genreRepository.GetGenresForPerson(personId);
            return Ok(genres);
        }
        [HttpGet("~/api/genres/{genreId}/suggestions")]
        public async Task<IActionResult> GetMovieSuggestions(int genreId)
        {
            try
            {
                var recommendations = await _tmdbService.GetMovieRecommendationsAsync(genreId.ToString());
                return Ok(recommendations.Results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching movie recommendations: {ex.Message}");
            }
        }

    }
}