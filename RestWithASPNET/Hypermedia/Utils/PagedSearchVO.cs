using System;
using System.Collections.Generic;
using RestWithASPNET.Hypermedia.Abstract;

namespace RestWithASPNET.Hypermedia.Utils
{
    public class PagedSearchVO<Template> where Template : ISupportsHyperMedia
    {
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalResults { get; set; }

        public string SortFields { get; set; }

        public string SortDirections { get; set; }

        public Dictionary<string, Object> Filters { get; set; }

        public List<Template> List { get; set; }

        public PagedSearchVO(int currentPage, int pageSize, int totalResults, string sortFields, string sortDirections, Dictionary<string, object> filters, List<Template> list)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalResults = totalResults;
            SortFields = sortFields;
            SortDirections = sortDirections;
            Filters = filters;
            List = list;
        }

        public PagedSearchVO(int currentPage, int pageSize, string sortFields, string sortDirections)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            SortFields = sortFields;
            SortDirections = sortDirections;
        }

        public PagedSearchVO(int currentPage, string sortFields, string sortDirections)
            : this (currentPage, 10, sortFields, sortDirections) {}

        public PagedSearchVO()
        {
        }

        public int GetCurrentPage()
        {
            return CurrentPage == 0 ? 2 : CurrentPage;
        }

        public int GetPageSize()
        {
            return PageSize == 0 ? 10 : PageSize;
        }
    }
}