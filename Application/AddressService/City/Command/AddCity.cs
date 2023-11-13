using Application.AddressService.City.Command.Dto;
using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using AutoMapper;

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