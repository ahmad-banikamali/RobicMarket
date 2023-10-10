using Domain;

namespace Application.CommentService.Query.ReadMultipleComments.Dto;

public class ReadMultipleCommentsResponse
{
    public DateTime InsertTime { get; set; }
    public string Text { get; set; }
    public ICollection<ReadMultipleCommentsResponse> AnswerComments { get; set; } = new List<ReadMultipleCommentsResponse>();
}