using Microsoft.EntityFrameworkCore;

namespace WebApplication1App.Data
{
    namespace WebApplication1App.Data
    {
        public class PersonRepository : IPersonRepository
        {
            private readonly WebApplication1AppDbContext _context;

            public PersonRepository(WebApplication1AppDbContext context)
            {
                _context = context;
            }

            public IEnumerable<Person> GetAllPeople() //get all people
        {
            return _context.People.ToList();
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
        public IEnumerable<Person> GetPeopleForPerson(int personId)
        {
            return _context.People.Where(p => p.Id == personId).ToList();
        }
        public void LinkPersonToGenre(int personId, int genreId)
        {
            var person = _context.People.FirstOrDefault(p => p.Id == personId);
            var genre = _context.Genres.FirstOrDefault(g => g.Id == genreId);

            if (person != null && genre != null)
            {
                person.Genres.Add(genre);
                _context.SaveChanges();
            }
        }
            public void AddMovieLinksForPersonAndGenre(int personId, int genreId, List<MovieLink> movieLinks)
            {
               
                var person = _context.People.FirstOrDefault(p => p.Id == personId);
                var genre = _context.Genres.FirstOrDefault(g => g.Id == genreId);

                if (person != null && genre != null)
                {
                    foreach (var movieLink in movieLinks)
                    {
                        // Associate the movie link with the person and genre
                        movieLink.Person = person;
                        movieLink.Genre = genre;

                        _context.MovieLinks.Add(movieLink);
                    }

                    _context.SaveChanges();
                }
            }

        }
    }
}

