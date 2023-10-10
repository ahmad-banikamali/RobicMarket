namespace Common.BaseDto
{
    public class PaginatedResponse<T>
    {
        public int PageIndex { get; set; }
        public int MaxItemsPerPage { get; set; }
        public long ItemCountInPage { get; set; }
        public IEnumerable<T> Data { get; set; } = new List<T>();
    }
}