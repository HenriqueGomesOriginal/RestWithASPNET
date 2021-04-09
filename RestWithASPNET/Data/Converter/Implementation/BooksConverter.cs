using RestWithASPNET.Data.Converter.Contract;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Data.Converter.Implementation
{
    public class BooksConverter : IParser<BooksVO, Books>, IParser<Books, BooksVO>
    {
        public Books Parse(BooksVO source)
        {
            if (source == null) return null;
            return new Books
            {
                Id = source.Id,
                Author = source.Author,
                Launch = source.Launch,
                Price = source.Price,
                Title = source.Title
            };
        }

        public List<Books> Parse(List<BooksVO> source)
        {
            if (source == null) return null;
            return source.Select(item => Parse(item)).ToList();
        }

        public BooksVO Parse(Books source)
        {
            if (source == null) return null;
            return new BooksVO
            {
                Id = source.Id,
                Author = source.Author,
                Launch = source.Launch,
                Price = source.Price,
                Title = source.Title
            };
        }

        public List<BooksVO> Parse(List<Books> source)
        {
            if (source == null) return null;
            return source.Select(item => Parse(item)).ToList();
        }
    }
}
