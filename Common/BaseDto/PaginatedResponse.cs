namespace Common.BaseDto
{
    public class PaginatedResponse<T>
    {
        public int PageNumber { get; set; } 
        public IEnumerable<T> Data { get; set; } = new List<T>();
    }
}