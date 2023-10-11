using Domain;

namespace Application.CommentService.Query.ReadMultipleComments.Dto;

public class ReadMultipleCommentsResponse
{
    public int? ParentCommentId { get; set; }
    public DateTime InsertTime { get; set; }
    public string Text { get; set; }
    public ICollection<ReadMultipleCommentsResponse>? AnswerComments { get; set; }
}