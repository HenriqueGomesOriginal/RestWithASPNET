using RestWithASPNET.Models;
using RestWithASPNET.Models.Base;
using System.Collections.Generic;

namespace RestWithASPNET.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(string id);
        List<T> FindAll();
        T Update(T item);
        T Delete(string id);
        bool Exists(string id);
    }
}
