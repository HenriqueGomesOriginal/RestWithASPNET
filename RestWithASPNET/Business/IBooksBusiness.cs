using RestWithASPNET.Data.VO;
using RestWithASPNET.Hypermedia.Utils;
using System.Collections.Generic;

namespace RestWithASPNET.Business
{
    public interface IBooksBusiness
    {
        BooksVO Create(BooksVO books);
        BooksVO FindById(string id);
        List<BooksVO> FindAll();
        BooksVO Update(BooksVO books);
        BooksVO Delete(string id);
        PagedSearchVO<BooksVO> FindWithPagedSearch(string name, string sortDirection,
            int pageSize, int currentPage);
    }
}
