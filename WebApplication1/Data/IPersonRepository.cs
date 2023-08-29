using System;

namespace WebApplication1.Data
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAllPeople();
        Person GetPersonById(int id);
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(int id);
        
    }
}
