using Application.ProductService.Product.Command.Create.Dto;
using Application.ProductService.Product.Command.Delete.Dto;
using Application.ProductService.Product.Command.Update.Dto;
using Application.ProductService.Product.Common;
using Application.ProductService.Product.Query.ReadMultiple.Dto;
using Application.ProductService.Product.Query.ReadSingle.Dto;
using AutoMapper;
using Domain;

namespace Application.Utils
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Color, ColorDto>().ReverseMap();
            CreateMap<GuaranteeType, GuaranteeTypeDto>().ReverseMap();
            CreateMap<ImageUrl, ImageUrlDto>().ReverseMap();

            CreateMap<Product, CreateProductRequest>().ReverseMap();

            CreateMap<Product, ReadSingleProductRequest>().ReverseMap();
            CreateMap<Product, ReadSingleProductResponse>().ReverseMap();
            
            CreateMap<Product, ReadMultipleProductsRequest>().ReverseMap();
            CreateMap<Product, ReadMultipleProductsResponse>().ReverseMap();
            
            CreateMap<Product, UpdateProductRequest>().ReverseMap();
            
            CreateMap<Product, DeleteProductRequest>().ReverseMap();

        }
    }
}
