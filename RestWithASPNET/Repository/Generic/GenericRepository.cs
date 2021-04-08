using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Models.Base;
using RestWithASPNET.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySqlContext _context;
        private DbSet<T> dataset;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            item.Id = System.Guid.NewGuid().ToString();

            try
            {
                dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return item;
        }

        public T Delete(string id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            return result;
        }

        public bool Exists(string id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(string id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));

            return result;
        }

        public T Update(T item)
        {
            if (!Exists(item.Id)) return null;
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(item.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();

                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return item;
        }
    }
}
