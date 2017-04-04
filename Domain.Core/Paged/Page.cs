using System;
using System.Collections.Generic;

namespace Domain.Core.Paged
{
    public class Page<T> : IPage<T>
    {
        public Page(List<T> items, int pageIndex, int pageSize, long totalCount)
        {
            Items = items;
            TotalCount = totalCount;
            PageCount = (int)Math.Ceiling(totalCount / (double)pageSize);
            CurrentPage = pageIndex;
            PageSize = pageSize;
        }

        public List<T> Items { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public long TotalCount { get; set; }

        public int PageCount { get; private set; }
    }
}
