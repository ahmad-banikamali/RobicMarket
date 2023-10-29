using Application.BasketService.Command.Create.BasketItem.Dto;
using Application.BasketService.Query.Basket.Read;
using Application.BasketService.Query.Basket.Read.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Microsoft.EntityFrameworkCore;

namespace Application.BasketService.Command.Create.BasketItem;

public class AddBasketItemToBasket:Command<Domain.BasketItem,AddBasketItemToBasketRequest>
{ 

    public AddBasketItemToBasket(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
      
    }

    public override Response Execute(AddBasketItemToBasketRequest request)
    {
        DbSet.Add(Mapper.Map<Domain.BasketItem>(request));
        SaveChanges();
        return new Response();
    }
}