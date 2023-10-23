namespace Common.BaseDto
{
    public class PaginatedResponse<T>
    {
        public int PageNumber { get; set; } 
        public IEnumerable<T> Data { get; set; } = new List<T>();
        
        public List<string> Message { get; set; } = new List<string>();

    }
}