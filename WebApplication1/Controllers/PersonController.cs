using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
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

        // GET: api/person
        [HttpGet]
        public IActionResult GetAllPeople()
        {
            var people = _personRepository.GetAllPeople();
            return Ok(people);
        }

        // GET: api/person/1
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

        // POST: api/person
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

        // PUT: api/person/1
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

        // DELETE: api/person/1
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
    }
}