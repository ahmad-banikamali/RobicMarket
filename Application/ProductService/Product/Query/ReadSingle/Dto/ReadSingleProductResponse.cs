using Application.ProductService.Product.Common;

namespace Application.ProductService.Product.Query.ReadSingle.Dto;
public class ReadSingleProductResponse
    { 
        public string Name { get; set; }
        public string Description { get; set; }
        public string SmallDescription { get; set; }

        public ICollection<ImageUrlDto> ImageUrls { get; set; } = new List<ImageUrlDto>();     

        public byte StarCount { get; set; }  

        public int Price { get; set; }
        public ICollection<ColorDto> Colors { get; set; } = new List<ColorDto>();

        public ICollection<GuaranteeTypeDto> GuaranteeTypes { get; set; } = new List<GuaranteeTypeDto>();

        public int Inventory { get; set; }
        public string Review { get; set; }
        
        public ICollection<CommentWithProduct>? Comments { get; set; } 

    }





 
