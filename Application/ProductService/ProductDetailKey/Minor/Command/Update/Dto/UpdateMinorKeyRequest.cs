namespace Application.ProductService.ProductDetailKey.Minor.Command.Update.Dto;

public class UpdateMinorKeyRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int MajorKeyId { get; set; }
}