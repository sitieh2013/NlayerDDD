namespace Domain.Core.Paged
{
    public interface IPageable
    {
        int CurrentPage { get; set; }

        int PageSize { get; set; }
    }
}
