using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SportsStoreApp.Models.Pages
{
    public class PagedList<T> : List<T>
    {
        public PagedList(IQueryable<T> query, QueryOptions options = null)
        {
            CurrentPage = options.CurrentPage;
            PageSize = options.PageSize;
            
            TotalPages = query.Count() / PageSize;
            AddRange(query.Skip((CurrentPage - 1) * PageSize).Take(PageSize));
        }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public QueryOptions Options { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }
}
