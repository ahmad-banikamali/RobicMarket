namespace Application.CommentService.Query.ReadMultipleComments.Dto;

public class ReadMultipleCommentsRequest
{
    public int ProductId { get; set; }
    public int PageSize { get; set; }
    public int Skip { get; set; }
}