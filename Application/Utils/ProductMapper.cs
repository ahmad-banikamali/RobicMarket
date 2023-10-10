using Application.ProductService.Command.Create.Dto;
using Application.ProductService.Command.Delete.Dto;
using Application.ProductService.Command.Update.Dto;
using Application.ProductService.Common;
using Application.ProductService.Query.ReadMultiProducts.Dto;
using Application.ProductService.Query.ReadSingleProduct.Dto;
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
            
            CreateMap<Product, ReadPaginatedProductsRequest>().ReverseMap();
            CreateMap<Product, ReadPaginatedProductsResponse>().ReverseMap();
            
            CreateMap<Product, UpdateProductRequest>().ReverseMap();
            
            CreateMap<Product, DeleteProductRequest>().ReverseMap();

        }
    }
}
