using Application.BasketService.Command.Create.Basket.Dto;
using Application.BasketService.Command.Create.BasketItem.Dto;
using Application.BasketService.Query.Basket.Read.Dto;
using AutoMapper;
using Domain;

namespace Application.Utils.Mapper;

public class BasketMapper : Profile
{
    public BasketMapper()
    {
        CreateMap<AddBasketToBuyerRequest, Basket>().ReverseMap();
        CreateMap<ReadBasketResponse, Basket>().ReverseMap();
        CreateMap<AddBasketItemToBasketRequest, BasketItem>().ReverseMap();
        CreateMap<BasketItem, BasketItemResponse>()
            .ForMember(x=>x.Name,y=>y.MapFrom(z=>z.Product.Name))
            .ForMember(x=>x.Price,y=>y.MapFrom(z=>z.Product.Price))
            .ReverseMap(); 
    }
}