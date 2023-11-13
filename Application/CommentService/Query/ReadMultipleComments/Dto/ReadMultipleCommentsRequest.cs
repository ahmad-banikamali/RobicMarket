using Application.Common.BaseDto;

namespace Application.CommentService.Query.ReadMultipleComments.Dto;

public class ReadMultipleCommentsRequest : PaginatedRequest
{
    public int ProductId { get; set; }
}