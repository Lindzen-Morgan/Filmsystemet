using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1App.Data;

namespace WebApplication1App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        //get all persons API ENDPOINT
        
        [HttpGet]
        public IActionResult GetAllPeople(string nameFilter, int page = 1, int pageSize = 10)
        {
            var people = _personRepository.GetAllPeople();

            if (!string.IsNullOrEmpty(nameFilter))
            {
                // Apply the name filter if provided
                people = people.Where(p => p.Name.Contains(nameFilter, StringComparison.OrdinalIgnoreCase));
            }

            var totalCount = people.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var results = people.Skip((page - 1) * pageSize).Take(pageSize);

            var response = new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                Page = page,
                PageSize = pageSize,
                Results = results
            };

            return Ok(response);
        }





        //Get api/person id
        [HttpGet("{id}")]
        public IActionResult GetPersonById(int id)
        {
            var person = _personRepository.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        //Post Person result
        [HttpPost]
        public IActionResult AddPerson([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            _personRepository.AddPerson(person);
            return CreatedAtAction(nameof(GetPersonById), new { id = person.Id }, person);
        }

        //put api person id
        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, [FromBody] Person person)
        {
            if (person == null || id != person.Id)
            {
                return BadRequest();
            }

            _personRepository.UpdatePerson(person);
            return NoContent();
        }

        //delete person id
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            var person = _personRepository.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }

            _personRepository.DeletePerson(id);
            return NoContent();
        }
        
        [HttpGet("~/api/Person/{personId}/people")]
        public IActionResult GetPeopleForPerson(int personId)
        {
            var people = _personRepository.GetPeopleForPerson(personId);
            return Ok(people);
        }
        [HttpPost("{personId}/genres/{genreId}")] // Link person to genre
        public IActionResult LinkPersonToGenre(int personId, [FromBody] int genreId)
        {
            _personRepository.LinkPersonToGenre(personId, genreId);
            return NoContent();
        }

        [HttpGet("{personId}/genres")] // Get genres for a person
        public IActionResult GetGenresForPerson(int personId)
        {
            var person = _personRepository.GetPersonById(personId);
            if (person == null)
            {
                return NotFound();
            }

            var genres = person.GenresInterested; // Loading genres for person

            return Ok(genres);
        }
        [HttpPost("~/api/Person/{personId}/genres/{genreId}/links")]
        public IActionResult AddMovieLinksForPersonAndGenre(int personId, int genreId, [FromBody] List<MovieLink> movieLinks)
        {
            _personRepository.AddMovieLinksForPersonAndGenre(personId, genreId, movieLinks);
            return NoContent();
        }
        [HttpGet("{id}/genres-and-links")]
        public IActionResult GetGenresAndLinksForPerson(int id)
        {
            var person = _personRepository.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }

            var result = new
            {
                Person = new
                {
                    Id = person.Id,
                    Name = person.Name,
                    Email = person.Email
                },
                Genres = person.GenresInterested,
                Links = person.MovieLinks
            };

            return Ok(result);
        }
        
        [ApiController]
        [Route("api/ratings")]
        public class RatingController : ControllerBase
        {
            private readonly IRatingRepository _ratingRepository;

            public RatingController(IRatingRepository ratingRepository)
            {
                _ratingRepository = ratingRepository;
            }

            [HttpPost]
            public async Task<IActionResult> AddRating([FromBody] Rating rating)
            {
                var addedRating = await _ratingRepository.AddRatingAsync(rating);
                return Ok(addedRating);
            }

            [HttpGet("{personId}")]
            public async Task<IActionResult> GetRatingsForPerson(int personId)
            {
                var ratings = await _ratingRepository.GetRatingsForPersonAsync(personId);
                return Ok(ratings);
            }
        }



    }
}