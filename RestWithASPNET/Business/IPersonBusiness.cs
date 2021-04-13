using RestWithASPNET.Data.VO;
using RestWithASPNET.Hypermedia.Utils;
using RestWithASPNET.Models;
using System.Collections.Generic;

namespace RestWithASPNET.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(string id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        PersonVO Delete(string id);
        PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection,
            int pageSize, int currentPage);
    }
}
