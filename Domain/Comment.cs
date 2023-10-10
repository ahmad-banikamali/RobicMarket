namespace Domain;

public class Comment
{
    public int Id { get; set; }
    public string Text { get; set; }

    public DateTime InsertTime { get; set; }
    
    public ICollection<Comment> AnswerComments { get; set; } = new List<Comment>();

    public Comment? ParentComment { get; set; }
    public int? ParentCommentId { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; }
}