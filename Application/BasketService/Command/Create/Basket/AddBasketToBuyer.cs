using Application.BasketService.Command.Create.Basket.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;

namespace Application.BasketService.Command.Create.Basket;

public class AddBasketToBuyer : Command<AddBasketToBuyerRequest>
{
    public AddBasketToBuyer(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(AddBasketToBuyerRequest request)
    {
        var basket = DatabaseContext.Baskets.Find(request.BuyerId);
        if (basket != null) return new Response();
        DatabaseContext.Baskets.Add(Mapper.Map<Domain.Basket>(request));
        DatabaseContext.SaveChanges();
        return new Response();
    }
}