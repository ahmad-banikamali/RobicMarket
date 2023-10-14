using Application.ProductService.ProductDetailKey.Major.Command.Create.Dto;
using Application.ProductService.ProductDetailKey.Major.Command.Update.Dto;
using Application.ProductService.ProductDetailKey.Major.Query.ReadMultiple.Dto;
using Application.ProductService.ProductDetailKey.Major.Query.ReadSingle.Dto;
using Application.ProductService.ProductDetailKey.Minor.Command.Create.Dto;
using Application.ProductService.ProductDetailKey.Minor.Command.Update;
using Application.ProductService.ProductDetailKey.Minor.Command.Update.Dto;
using Application.ProductService.ProductDetailKey.Minor.Query.ReadMultiple.Dto;
using Application.ProductService.ProductDetailKey.Minor.Query.ReadSingle.Dto;
using AutoMapper;
using Domain;

namespace Application.Utils;

public class ProductKeyMapper : Profile
{
    public ProductKeyMapper()
    {
        CreateMap<CreateMajorKeyRequest, MajorKey>().ReverseMap();
        CreateMap<UpdateMajorKeyRequest, MajorKey>().ReverseMap();

        CreateMap<ReadMultiMajorKeysResponse, MajorKey>().ReverseMap();
        CreateMap<ReadSingleMajorKeyResponse, MajorKey>().ReverseMap();
        CreateMap<UpdateMinorKeyRequest, MajorKey>().ReverseMap();

        CreateMap<CreateMinorKeyRequest, MinorKey>().ReverseMap();
        CreateMap<UpdateMinorKeyRequest, MinorKey>().ReverseMap();
        CreateMap<MinorKey, ReadMultipleMinorKeysResponse>()
            .ForMember(x => x.MajorKeyName,
                y =>
                    y.MapFrom(x => x.MajorKey.Name))
            .ReverseMap();

        CreateMap<ReadSingleMinorKeyResponse, MinorKey>()
            .ForPath(x => x.MajorKey.Name, y => y.MapFrom(
                z => z.MajorKeyName
            ))
            .ReverseMap();
    }
}