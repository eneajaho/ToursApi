using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToursApi.Helpers
{
    public class PagedData<T>
    {
        public PagedList<T> Data { get; set; }

        public Pagination<T> Pagination { get; set; }

        public PagedData(PagedList<T> pagedList)
        {
            Data = pagedList;
            Pagination = new Pagination<T>(pagedList);
        }
        
        public static async Task<PagedData<T>> CreateAsync(IQueryable<T> source, PaginationParams paginationParams)
        {
            var (pageNumber, pageSize) = paginationParams;
            
            var count = await source.CountAsync();
            
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedData<T>(new PagedList<T>(items, count, pageNumber, pageSize));
        }
    }
    
    public class PagedList<T> : List<T>
    {
        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int) Math.Ceiling(count / (double) pageSize);
            AddRange(items);
        }

        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
    }


    public class Pagination<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }

        public Pagination(PagedList<T> pagedList)
        {
            CurrentPage = pagedList.CurrentPage;
            TotalPages = pagedList.TotalPages;
            PageSize = pagedList.PageSize;
            TotalCount = pagedList.TotalCount;
            HasPrevious = pagedList.HasPrevious;
            HasNext = pagedList.HasNext;
        }
    }
}