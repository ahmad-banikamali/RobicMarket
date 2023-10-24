using Application.AddressService.City.Command.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;

namespace Application.AddressService.City.Command;

public class AddCity : Command<Domain.City, AddCityRequest>
{
    public AddCity(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(AddCityRequest request)
    {
        DbSet.Add(Mapper.Map<Domain.City>(request));
        SaveChanges();
        return new Response();
    }
}