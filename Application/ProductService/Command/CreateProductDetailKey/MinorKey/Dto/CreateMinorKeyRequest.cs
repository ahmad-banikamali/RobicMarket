namespace Application.ProductService.Command.CreateProductDetailKey.MinorKey.Dto;

public class CreateMinorKeyRequest
{
    public string Name { get; set; }
    public int MajorKeyId { get; set; }
}