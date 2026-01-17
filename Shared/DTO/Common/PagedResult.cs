namespace pressAgency.Shared.DTO.Common
{
    public class PagedResult<T>
    {
        public List<T>? Records { get; set; } = [];
        public Pagination? Pagination { get; set; } = new Pagination();
    }

    public class Pagination
    {
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRecord { get; set; }
    }
}
