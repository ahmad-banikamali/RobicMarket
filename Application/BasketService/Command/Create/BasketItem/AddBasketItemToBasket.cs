

using Application.BasketService.Command.Dto;
using Application.BasketService.Query.Basket.Read;
using Application.BasketService.Query.Basket.Read.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;

namespace Application.BasketService.Command.Create.BasketItem;

public class AddBasketItemToBasket:Command<AddBasketItemToBasketRequest>
{
    private readonly ReadBasket _readBasket;

    public AddBasketItemToBasket(ReadBasket readBasket,IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
        _readBasket = readBasket;
    }

    public override Response Execute(AddBasketItemToBasketRequest request)
    {
        var response = _readBasket.Execute(new ReadBasketRequest(){BuyerId = request.BuyerId});
        if (response.Data == null) return new Response(){IsSuccess = false};
        var basketId = response.Data.Id;
        var basket = DatabaseContext.Baskets.FirstOrDefault(x => x.Id == basketId);
        if(basket==null)  return new Response(){IsSuccess = false};

        basket.BasketItems.Add(Mapper.Map<Domain.BasketItem>(request));
        DatabaseContext.SaveChanges();
        return new Response();
    }
}