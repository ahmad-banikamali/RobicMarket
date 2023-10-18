namespace Application.ProductService.Product.Query.ReadSingle.Dto;

public class CommentWithProduct
{
    public string UserName { get; set; }
    public int? ParentCommentId { get; set; }
    public DateTime InsertTime { get; set; }
    public string Text { get; set; }
    public ICollection<CommentWithProduct> AnswerComments { get; set; } = new List<CommentWithProduct>();
}