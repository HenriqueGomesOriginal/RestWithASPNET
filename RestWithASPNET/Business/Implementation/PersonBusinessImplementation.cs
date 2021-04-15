using RestWithASPNET.Data.Converter.Implementation;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Hypermedia.Utils;
using RestWithASPNET.Models;
using RestWithASPNET.Repository;
using System.Collections.Generic;

namespace RestWithASPNET.Business.Implementation
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private IRepository<Person> _personRepository;
        private PersonConverter _converter;

        public PersonBusinessImplementation(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            return _converter.Parse(_personRepository.Create(personEntity));
        }

        public PersonVO Delete(string id)
        {
            return _converter.Parse(_personRepository.Delete(id));
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_personRepository.FindAll());
        }
        public PersonVO FindById(string id)
        {
            return _converter.Parse(_personRepository.FindById(id));
        }

        public PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection,
            int pageSize, int currentPage)
        {
            var offset = pageSize > 0 ? (pageSize - 1) * pageSize : 0;
            var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = (pageSize < 1) ? 1 : pageSize;

            string query = @"select * from person p where p.name like '%"
                + name + "%' order by p.name " + sort + " limit " + pageSize +
                " offset " + currentPage;

            string countQuery = @"select count(*) from person p";

            var persons = _personRepository.FindWithPagedSearch(query);
            int total = _personRepository.GetCount(countQuery);

            return new PagedSearchVO<PersonVO> {
                CurrentPage = offset,
                List = _converter.Parse(persons),
                PageSize = size,
                SortDirections = sort,
                TotalResults = total
            };
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            return _converter.Parse(_personRepository.Update(personEntity));
        }
    }
}
