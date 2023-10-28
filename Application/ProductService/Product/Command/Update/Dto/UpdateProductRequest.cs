using Application.ProductService.Product.Common;

namespace Application.ProductService.Product.Command.Update.Dto;

public class UpdateProductRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string SmallDescription { get; set; }

    public ICollection<ImageUrlDto> ImageUrls { get; set; } = new List<ImageUrlDto>();     

    public byte StarCount { get; set; }  

    public int Price { get; set; }
    public ICollection<WriteColorDto> Colors { get; set; } = new List<WriteColorDto>();

    public ICollection<WriteGuaranteeTypeDto> GuaranteeTypes { get; set; } = new List<WriteGuaranteeTypeDto>();

    public int Inventory { get; set; }
    public string Review { get; set; }

}