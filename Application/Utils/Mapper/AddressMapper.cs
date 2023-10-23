using Application.AddressService.City.Command.Dto;
using Application.AddressService.City.Query.ReadMultiple.Dto;
using Application.AddressService.DefaultAddress.Query.Read.Dto;
using Application.AddressService.NormalAddress.Command.Dto;
using Application.AddressService.NormalAddress.Query.ReadMultiple.Dto;
using Application.AddressService.Province.Command.Dto;
using Application.AddressService.Province.Query.ReadMultiple.Dto;
using AutoMapper;
using Domain;

namespace Application.Utils.Mapper;

public class AddressMapper:Profile
{
    public AddressMapper()
    {
        CreateMap<AddCityRequest, City>();
        CreateMap<City, ReadMultipleCitiesResponse>();
        
        CreateMap<AddProvinceRequest, Province>();
        CreateMap<Province, ReadMultipleProvincesResponse>();
        
        
        CreateMap<AddNormalAddressRequest, Address>();
        CreateMap<Address, ReadDefaultAddressResponse>()
            .ForMember(x=>x.CityName,y=>
                y.MapFrom(z=>z.City.Name));
        CreateMap<Address, ReadMultipleAddressResponse>()
            .ForMember(x=>x.CityName,y=>
                y.MapFrom(z=>z.City.Name));
        
        
    }
}