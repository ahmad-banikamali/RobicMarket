using Application.ProductService.Product.Common;
using AutoMapper;
using Domain;

namespace Application.Utils;

public class ProductDetailItemMapper:Profile
{
    public ProductDetailItemMapper()
    {
        CreateMap<ProductDetailItem, ReadProductDetailItemDto>()
            .ForMember(
                x=>
                    x.Name,y=>
                    y.MapFrom(z=>z.MinorKey.Name))
            .ForMember(x=>
                x.MajorKeyName,y=>
                y.MapFrom(z=>z.MinorKey.MajorKey.Name))
            .ReverseMap();
        
    }
    
}