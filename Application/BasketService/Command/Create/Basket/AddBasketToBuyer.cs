using Application.BasketService.Command.Create.Basket.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;

namespace Application.BasketService.Command.Create.Basket;

public class AddBasketToBuyer : Command<Domain.Basket,AddBasketToBuyerRequest>
{
    public AddBasketToBuyer(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(AddBasketToBuyerRequest request)
    {
        var basket = DbSet.FirstOrDefault(x=>x.BuyerId == request.BuyerId);
        if (basket != null) return new Response();
        DbSet.Add(Mapper.Map<Domain.Basket>(request));
        SaveChanges();
        return new Response();
    }
}