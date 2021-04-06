using RestWithASPNET.Models;
using RestWithASPNET.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Services.Implementation
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySqlContext _context;

        public PersonServiceImplementation(MySqlContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return person;
        }

        public Person Delete(string id)
        {
            if (!Exists(id)) return new Person();
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            return result;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        private Person MockPerson()
        {
            return new Person
            {
                Id = System.Guid.NewGuid().ToString(),
                Name = "Henrique",
                LastName = "Gomes",
                Address = "Rio de Janeiro",
                Gender = "Male"
            };
        }

        public Person FindById(string id)
        {
            if (!Exists(id)) return new Person();
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            return result;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return person;
        }

        private bool Exists(string id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
