using RestWithASPNET.Models;
using System.Collections.Generic;

namespace RestWithASPNET.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(string id);
        List<Person> FindAll();
        Person Update(Person person);
        Person Delete(string id);
    }
}
