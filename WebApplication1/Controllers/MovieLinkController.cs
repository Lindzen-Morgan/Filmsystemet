using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1App.Data;

namespace WebApplication1App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieLinkController : ControllerBase
    {
        private readonly IMovieLinkRepository _movieLinkRepository;

        public MovieLinkController(IMovieLinkRepository movieLinkRepository)
        {
            _movieLinkRepository = movieLinkRepository;
        }
        //get all movie links
        [HttpGet]
        public IActionResult GetAllMovieLinks()
        {
            var movieLinks = _movieLinkRepository.GetAllMovieLinks();
            return Ok(movieLinks);
        }
        //get movie link by id
        [HttpGet("{id}")]
        public IActionResult GetMovieLinkById(int id)
        {
            var movieLink = _movieLinkRepository.GetMovieLinkById(id);
            if (movieLink == null)
            {
                return NotFound();
            }
            return Ok(movieLink);
        }

        [HttpPost]
        //add movie link
        public IActionResult AddMovieLink([FromBody] MovieLink movieLink)
        {
            if (movieLink == null)
            {
                return BadRequest();
            }

            _movieLinkRepository.AddMovieLink(movieLink);
            return CreatedAtAction(nameof(GetMovieLinkById), new { id = movieLink.Id }, movieLink);
        }
        //update by id
        [HttpPut("{id}")]
        public IActionResult UpdateMovieLink(int id, [FromBody] MovieLink movieLink)
        {
            if (movieLink == null || id != movieLink.Id)
            {
                return BadRequest();
            }

            _movieLinkRepository.UpdateMovieLink(movieLink);
            return NoContent();
        }
        //delete by id
        [HttpDelete("{id}")]
        public IActionResult DeleteMovieLink(int id)
        {
            var movieLink = _movieLinkRepository.GetMovieLinkById(id);
            if (movieLink == null)
            {
                return NotFound();
            }

            _movieLinkRepository.DeleteMovieLink(id);
            return NoContent();
        }
        [HttpGet("~/api/Person/{personId}/movielinks")] //get all movies connected to a person
        public IActionResult GetMovieLinksForPerson(int personId)
        {
            var movieLinks = _movieLinkRepository.GetMovieLinksForPerson(personId);
            return Ok(movieLinks);
        }
        [HttpGet("~/api/Person/{personId}/movielinks/{movieLinkId}/rating")]
        public IActionResult GetMovieLinkRating(int personId, int movieLinkId)
        {
            var rating = _movieLinkRepository.GetMovieLinkRating(personId, movieLinkId);
            if (rating == null)
            {
                return NotFound();
            }
            return Ok(rating);
        }
        [HttpPost("~/api/Person/{personId}/movielinks/{movieLinkId}/rating")]
        public IActionResult AddMovieLinkRating(int personId, int movieLinkId, [FromBody] MovieLinkRating rating) //adding Rating
        {
            if (rating == null)
            {
                return BadRequest();
            }

            _movieLinkRepository.AddMovieLinkRating(personId, movieLinkId, rating);
            return CreatedAtAction(nameof(GetMovieLinkRating), new { personId, movieLinkId }, rating);
        }
        
    }
}
