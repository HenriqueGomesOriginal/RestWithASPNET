using RestWithASPNET.Data.Converter.Implementation;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Models;
using RestWithASPNET.Repository;
using System.Collections.Generic;

namespace RestWithASPNET.Business.Implementation
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private IRepository<Person> _personRepository;
        private PersonConverter _converter;

        public PersonBusinessImplementation(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            return _converter.Parse(_personRepository.Create(personEntity));
        }

        public PersonVO Delete(string id)
        {
            return _converter.Parse(_personRepository.Delete(id));
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_personRepository.FindAll());
        }
        public PersonVO FindById(string id)
        {
            return _converter.Parse(_personRepository.FindById(id));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            return _converter.Parse(_personRepository.Update(personEntity));
        }
    }
}
