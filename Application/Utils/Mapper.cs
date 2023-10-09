using Application.ProductService.Common;
using Application.ProductService.Create.Dto;
using Application.ProductService.Delete.Dto;
using Application.ProductService.Read.Dto;
using Application.ProductService.Update.Dto;
using AutoMapper;
using Domain;

namespace Application.Utils
{
    public class Mapper : Profile
    {
        public Mapper()
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
