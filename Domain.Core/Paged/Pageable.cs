namespace Domain.Core.Paged
{
    public class Pageable : IPageable
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
