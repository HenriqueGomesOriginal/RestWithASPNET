using RestWithASPNET.Models;
using System.Collections.Generic;

namespace RestWithASPNET.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(string id);
        List<Person> FindAll();
        Person Update(Person person);
        Person Delete(string id);
        bool Exists(string id);
    }
}
