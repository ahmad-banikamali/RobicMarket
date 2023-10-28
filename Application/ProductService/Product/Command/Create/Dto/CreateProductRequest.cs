using Application.ProductService.Product.Common;

namespace Application.ProductService.Product.Command.Create.Dto
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string SmallDescription { get; set; }

        public ICollection<ImageUrlDto> ImageUrls { get; set; } = new List<ImageUrlDto>();

        public byte StarCount { get; set; }

        public int Price { get; set; }
        public ICollection<WriteColorDto> Colors { get; set; } = new List<WriteColorDto>();

        public ICollection<WriteGuaranteeTypeDto> GuaranteeTypes { get; set; } = new List<WriteGuaranteeTypeDto>();
        public List<CreateProductDetailItemDto> ProductDetails { get; set; } = new List<CreateProductDetailItemDto>();

        public int Inventory { get; set; }
        public string Review { get; set; }
    }
}