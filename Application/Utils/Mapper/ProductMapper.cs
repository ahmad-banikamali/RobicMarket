using Application.ProductService.Product.Command.Create.Dto;
using Application.ProductService.Product.Command.Delete.Dto;
using Application.ProductService.Product.Command.Update.Dto;
using Application.ProductService.Product.Common;
using Application.ProductService.Product.Query.ReadMultiple.Dto;
using Application.ProductService.Product.Query.ReadSingle.Dto;
using Application.ProductService.ProductColor.Command.Dto;
using AutoMapper;
using Domain;

namespace Application.Utils.Mapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Color, ReadColorDto>().ReverseMap();
            CreateMap<GuaranteeType, ReadGuaranteeTypeDto>().ReverseMap();
            
            CreateMap<WriteColorDto,Color >().ReverseMap();
            CreateMap<GuaranteeType, WriteGuaranteeTypeDto>().ReverseMap();
            CreateMap<ImageUrl, ImageUrlDto>().ReverseMap();

            CreateMap<CreateProductRequest, Product>()
                .ReverseMap();

            CreateMap<Product, ReadSingleProductRequest>().ReverseMap();
            CreateMap<Product, ReadSingleProductResponse>().ForMember(
                x => x.ProductDetails,
                y =>
                    y.MapFrom(z => z.ProductDetails.GroupBy(x => x.MinorKey.MajorKey.Name)
                        .Select(x => new KeyValuePair<string, IEnumerable<KeyValuePair<string, string>>>(x.Key,
                            x.Select(m => new KeyValuePair<string, string>(m.MinorKey.Name, m.Value)))))
            );

            CreateMap<Product, ReadMultipleProductsRequest>().ReverseMap();
            CreateMap<Product, ReadMultipleProductsResponse>().ReverseMap();

            CreateMap<Product, UpdateProductRequest>().ReverseMap();

            CreateMap<Product, DeleteProductRequest>().ReverseMap();

            
            CreateMap<CreateColorRequest, Color>().ReverseMap();
        }
    }
}