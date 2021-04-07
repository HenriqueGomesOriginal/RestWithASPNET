using RestWithASPNET.Models;
using System.Collections.Generic;

namespace RestWithASPNET.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindById(string id);
        List<Person> FindAll();
        Person Update(Person person);
        Person Delete(string id);
    }
}
