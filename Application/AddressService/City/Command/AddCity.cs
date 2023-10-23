using Application.AddressService.City.Command.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;

namespace Application.AddressService.City.Command;

public class AddCity:Command<AddCityRequest>
{
    public AddCity(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(AddCityRequest request)
    {
        DatabaseContext.City.Add(Mapper.Map<Domain.City>(request));
        DatabaseContext.SaveChanges();
        return new Response();
    }
}