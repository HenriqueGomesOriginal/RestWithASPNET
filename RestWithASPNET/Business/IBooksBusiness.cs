using RestWithASPNET.Data.VO;
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
    }
}
