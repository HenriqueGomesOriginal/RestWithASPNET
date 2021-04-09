using RestWithASPNET.Data.Converter.Implementation;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Models;
using RestWithASPNET.Repository;
using System.Collections.Generic;

namespace RestWithASPNET.Business.Implementation
{
    public class BooksBusinessImplementation : IBooksBusiness
    {
        private IRepository<Books> _booksRepository;
        private BooksConverter _converter;

        public BooksBusinessImplementation(IRepository<Books> booksRepository)
        {
            _booksRepository = booksRepository;
            _converter = new BooksConverter();
        }

        public BooksVO Create(BooksVO books)
        {
            var booksEntity = _converter.Parse(books);
            return _converter.Parse(_booksRepository.Create(booksEntity));
        }

        public BooksVO Delete(string id)
        {
            return _converter.Parse(_booksRepository.Delete(id));
        }

        public List<BooksVO> FindAll()
        {
            return _converter.Parse(_booksRepository.FindAll());
        }

        public BooksVO FindById(string id)
        {
            return _converter.Parse(_booksRepository.FindById(id));
        }

        public BooksVO Update(BooksVO books)
        {
            var booksEntity = _converter.Parse(books);
            return _converter.Parse(_booksRepository.Update(booksEntity));
        }
    }
}
