using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAllPeople()
        {
            var people = _personRepository.GetAllPeople(); 
            return Ok(people);
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


    }
}