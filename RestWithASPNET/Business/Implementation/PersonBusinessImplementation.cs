using RestWithASPNET.Models;
using RestWithASPNET.Models.Context;
using RestWithASPNET.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Business.Implementation
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private IPersonRepository _personRepository;

        public PersonBusinessImplementation(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person Create(Person person)
        {
            return _personRepository.Create(person);
        }

        public Person Delete(string id)
        {
            return _personRepository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _personRepository.FindAll();
        }
        public Person FindById(string id)
        {
            return _personRepository.FindById(id);
        }

        public Person Update(Person person)
        {
            return _personRepository.Update(person);
        }
    }
}
