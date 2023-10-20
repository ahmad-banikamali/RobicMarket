using Application.BasketService.Command.Create.Basket;
using Application.BasketService.Command.Create.Basket.Dto;
using Application.BasketService.Query.Basket.Read.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Microsoft.EntityFrameworkCore;

namespace Application.BasketService.Query.Basket.Read;

public class ReadBasket : Query<ReadBasketRequest, ReadBasketResponse>
{
    private readonly AddBasketToBuyer _addBasketToBuyer;

    public ReadBasket(
        AddBasketToBuyer addBasketToBuyer,
        IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
        _addBasketToBuyer = addBasketToBuyer;
    }

    public override Response<ReadBasketResponse> Execute(ReadBasketRequest request)
    {
        var basket = DatabaseContext.Baskets
            .Include(x=>x.BasketItems)
            .ThenInclude(x=>x.Product)
            .FirstOrDefault(x => x.BuyerId == request.BuyerId);

        if (basket != null)
            return new Response<ReadBasketResponse>
            {
                Data = Mapper.Map<ReadBasketResponse>(basket)
            };

        _addBasketToBuyer.Execute(new AddBasketToBuyerRequest
        {
            BuyerId = request.BuyerId
        });
    
        basket = DatabaseContext.Baskets.Include(x=>x.BasketItems).ThenInclude(x=>x.Product).FirstOrDefault(x => x.BuyerId == request.BuyerId);

        return new Response<ReadBasketResponse>
        {
            Data = Mapper.Map<ReadBasketResponse>(basket)
        };
    }
}