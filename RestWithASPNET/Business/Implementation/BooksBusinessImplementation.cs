using RestWithASPNET.Models;
using RestWithASPNET.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Business.Implementation
{
    public class BooksBusinessImplementation : IBooksBusiness
    {
        private IBooksRepository _booksRepository;

        public BooksBusinessImplementation(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public Books Create(Books books)
        {
            return _booksRepository.Create(books);
        }

        public Books Delete(string id)
        {
            return _booksRepository.Delete(id);
        }

        public List<Books> FindAll()
        {
            return _booksRepository.FindAll();
        }

        public Books FindById(string id)
        {
            return _booksRepository.FindById(id);
        }

        public Books Update(Books books)
        {
            return _booksRepository.Update(books);
        }
    }
}
