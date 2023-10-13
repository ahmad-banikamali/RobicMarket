namespace Application.ProductService.ProductDetailKey.Minor.Command.Create.Dto;

public class CreateMinorKeyRequest
{
    public string Name { get; set; }
    public int MajorKeyId { get; set; }
}