using System.Collections.Generic;

namespace Domain.Core.Paged
{
    public interface IPage<T> : IPageable
    {
        long TotalCount { get; set; }

        List<T> Items { get; set; }
    }
}
