namespace Application.Common.BaseDto;

public class PaginatedRequest
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; } = 20;
}