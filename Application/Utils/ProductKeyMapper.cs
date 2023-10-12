using Application.ProductService.Command.CreateProductDetailKey.MajorKey.Dto;
using Application.ProductService.Command.CreateProductDetailKey.MinorKey.Dto;
using AutoMapper;
using Domain;

namespace Application.Utils;

public class ProductKeyMapper : Profile
{
    public ProductKeyMapper()
    {
        CreateMap<CreateMajorKeyRequest, MajorKey>().ReverseMap();
        CreateMap<CreateMinorKeyRequest, MinorKey>().ReverseMap();
    }
}