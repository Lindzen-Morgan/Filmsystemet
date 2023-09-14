using System;
using System.Collections.Generic;

namespace WebApplication1App.Data
{
    public interface IPersonRepository
    {
        Person GetPersonById(int id);
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(int id);
        IEnumerable<Person> GetPeopleForPerson(int personId);
        void LinkPersonToGenre(int personId, int genreId);
        IEnumerable<Person> GetAllPeople();
        void AddMovieLinksForPersonAndGenre(int personId, int genreId, List<MovieLink> movieLinks);


    }
}
