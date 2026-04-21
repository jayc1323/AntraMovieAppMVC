using System.Collections.Generic;

namespace ApplicationCore.Helper
{
    public class PaginatedResultSet<T> where T : class
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public IEnumerable<T> Data { get; set; }
    }
}