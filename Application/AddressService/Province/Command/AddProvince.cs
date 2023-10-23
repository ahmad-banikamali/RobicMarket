using Application.AddressService.Province.Command.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;

namespace Application.AddressService.Province.Command;

public class AddProvince:Command<AddProvinceRequest>
{
    public AddProvince(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(AddProvinceRequest request)
    {
        DatabaseContext.Province.Add(Mapper.Map<Domain.Province>(request));
        DatabaseContext.SaveChanges();
        return new Response();
    }
}