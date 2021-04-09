using RestWithASPNET.Data.Converter.Contract;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Data.Converter.Implementation
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO source)
        {
            if (source == null) return null;
            return new Person
            {
                Id = source.Id,
                Name = source.Name,
                LastName = source.LastName,
                Address = source.Address,
                Gender = source.Gender
            };
        }

        public List<Person> Parse(List<PersonVO> source)
        {
            if (source == null) return null;
            return source.Select(item => Parse(item)).ToList();
        }

        public PersonVO Parse(Person source)
        {
            if (source == null) return null;
            return new PersonVO
            {
                Id = source.Id,
                Name = source.Name,
                LastName = source.LastName,
                Address = source.Address,
                Gender = source.Gender
            };
        }

        public List<PersonVO> Parse(List<Person> source)
        {
            if (source == null) return null;
            return source.Select(item => Parse(item)).ToList();
        }
    }
}
