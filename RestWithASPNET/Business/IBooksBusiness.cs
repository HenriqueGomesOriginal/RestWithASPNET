using RestWithASPNET.Models;
using System.Collections.Generic;

namespace RestWithASPNET.Business
{
    public interface IBooksBusiness
    {
        Books Create(Books books);
        Books FindById(string id);
        List<Books> FindAll();
        Books Update(Books books);
        Books Delete(string id);
    }
}
