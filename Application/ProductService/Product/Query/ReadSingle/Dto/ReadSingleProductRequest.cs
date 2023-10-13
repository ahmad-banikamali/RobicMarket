namespace Application.ProductService.Product.Query.ReadSingle.Dto
{
    public class ReadSingleProductRequest
    {
        public int Id { get; set; }
        public int CommentPageNumber { get; set; }
        public int CommentPageSize { get; set; }
    }
}
