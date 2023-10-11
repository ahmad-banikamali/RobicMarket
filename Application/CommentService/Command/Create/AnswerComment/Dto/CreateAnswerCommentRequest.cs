namespace Application.CommentService.Command.Create.AnswerComment.Dto;

public class CreateAnswerCommentRequest
{
    public int ParentCommentId { get; set; }
    public string Text { get; set; }
}