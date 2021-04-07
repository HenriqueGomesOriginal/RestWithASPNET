using RestWithASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Repository.Implementation
{
    public interface IBooksRepository
    {
        Books Create(Books books);
        Books FindById(string id);
        List<Books> FindAll();
        Books Update(Books books);
        Books Delete(string id);
        bool Exists(string id);
    }
}
