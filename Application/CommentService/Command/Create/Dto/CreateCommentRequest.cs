using Common.BaseDto;

namespace Application.CommentService.Command.Create.Dto;

public class CreateCommentRequest 
{
    public int ProductId { get; set; }
    public int? ParentCommentId { get; set; }
    public string Text { get; set; }
}