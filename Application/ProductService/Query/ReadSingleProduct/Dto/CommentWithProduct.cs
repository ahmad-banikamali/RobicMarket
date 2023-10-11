using Domain;

namespace Application.ProductService.Query.ReadSingleProduct.Dto;

public class CommentWithProduct
{
    public int? ParentCommentId { get; set; }
    public DateTime InsertTime { get; set; }
    public string Text { get; set; }
    public ICollection<CommentWithProduct> AnswerComments { get; set; } = new List<CommentWithProduct>();
}