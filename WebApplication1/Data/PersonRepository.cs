using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DbContext _context; // Using the general DbContext type

        public PersonRepository(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _context.Set<Person>().ToList();
        }

        public Person GetPersonById(int id)
        {
            return _context.Set<Person>().FirstOrDefault(p => p.Id == id);
        }

        public void AddPerson(Person person)
        {
            _context.Set<Person>().Add(person);
            _context.SaveChanges();
        }

        public void UpdatePerson(Person person)
        {
            _context.Set<Person>().Update(person);
            _context.SaveChanges();
        }

        public void DeletePerson(int id)
        {
            var person = _context.Set<Person>().FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                _context.Set<Person>().Remove(person);
                _context.SaveChanges();
            }
        }
    }
}
