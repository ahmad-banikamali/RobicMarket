﻿using Application.BasketService.Command.Create.Basket.Dto;
using Application.BasketService.Command.Dto;
using Application.BasketService.Query.Basket.Read.Dto;
using AutoMapper;
using Domain;

namespace Application.Utils.Mapper;

public class BasketDto : Profile
{
    public BasketDto()
    {
        CreateMap<AddBasketToBuyerRequest, Basket>().ReverseMap();
        // CreateMap<ReadBasketResponse, Basket>().ForPath(x=>x.BasketItems,y=>y.MapFrom(z=>z.)).ReverseMap();
        
        
        CreateMap<AddBasketItemToBasketRequest, BasketItem>().ReverseMap();
        CreateMap<BasketItem, BasketItemResponse>().ForPath(x => x.Name, y => y.MapFrom(z => z.Product.Name))
            .ForMember(x => x.Price, y => y.MapFrom(z => z.Product.Price))
            .ReverseMap();
    }
}