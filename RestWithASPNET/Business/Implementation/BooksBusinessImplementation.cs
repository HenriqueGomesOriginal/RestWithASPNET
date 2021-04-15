using RestWithASPNET.Data.Converter.Implementation;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Hypermedia.Utils;
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

        public PagedSearchVO<BooksVO> FindWithPagedSearch(string name, string sortDirection,
            int pageSize, int currentPage)
        {
            var offset = pageSize > 0 ? (pageSize - 1) * pageSize : 0;
            var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = (pageSize < 1) ? 1 : pageSize;

            string query = @"select * from books p where p.title like '%"
                + name + "%' order by p.title " + sort + " limit " + pageSize +
                " offset " + currentPage;

            string countQuery = @"select count(*) from books p";

            var persons = _booksRepository.FindWithPagedSearch(query);
            int total = _booksRepository.GetCount(countQuery);

            return new PagedSearchVO<BooksVO>
            {
                CurrentPage = offset,
                List = _converter.Parse(persons),
                PageSize = size,
                SortDirections = sort,
                TotalResults = total
            };
        }

        public BooksVO Update(BooksVO books)
        {
            var booksEntity = _converter.Parse(books);
            return _converter.Parse(_booksRepository.Update(booksEntity));
        }
    }
}
