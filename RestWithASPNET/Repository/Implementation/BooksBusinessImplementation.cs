using RestWithASPNET.Models;
using RestWithASPNET.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Repository.Implementation
{
    public class BooksRepositoryImplementation : IBooksRepository
    {
        private MySqlContext _context;

        public BooksRepositoryImplementation(MySqlContext context)
        {
            _context = context;
        }

        public Books Create(Books books)
        {
            try
            {
                _context.Add(books);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return books;
        }

        public Books Delete(string id)
        {
            if (!Exists(id)) return new Books();
            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Books.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            return result;
        }

        public List<Books> FindAll()
        {
            return _context.Books.ToList();
        }
        public Books FindById(string id)
        {
            if (!Exists(id)) return new Books();
            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(id));

            return result;
        }

        public Books Update(Books books)
        {
            if (!Exists(books.Id)) return null;
            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(books.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(books);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return books;
        }

        public bool Exists(string id)
        {
            return _context.Books.Any(p => p.Id.Equals(id));
        }
    }
}
