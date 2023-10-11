namespace Application.CommentService.Command.Create.ParentComment.Dto;

public class CreateParentCommentRequest
{
    public int ProductId { get; set; }
    public string Text { get; set; }
}