using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Colegio.Core.CustomEntities
{
    public class PageList<T>: List<T>
    {
        public int CurrentPage { get; set; }
        public int TotlaPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPreviousPage => CurrentPage > 1; 
        public bool HasNextPage => CurrentPage < TotlaPages;
        public int? NextPageNumber => HasNextPage ? CurrentPage + 1 : (int?)null;
        public int? PreviousPageNumber => HasPreviousPage ? CurrentPage - 1 : (int?)null;

        public PageList(List<T> items, int count, int pageNumber , int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotlaPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        public static PageList<T> Create(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }
}
