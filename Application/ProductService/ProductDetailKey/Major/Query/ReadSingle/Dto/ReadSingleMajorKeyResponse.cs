 
namespace Application.ProductService.ProductDetailKey.Major.Query.ReadSingle.Dto;

public class ReadSingleMajorKeyResponse
{
    public string Name { get; set; }
    public ICollection<string> MinorKeys { get; set; }
}