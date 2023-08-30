using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
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
        [HttpGet("{personId}/genres")]
        public IActionResult GetGenresForPerson(int personId)
        {
            var genres = _genreRepository.GetGenresForPerson(personId); //fetching genre for persons
            return Ok(genres);
        }
    }
}