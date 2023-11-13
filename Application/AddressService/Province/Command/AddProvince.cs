using Application.AddressService.Province.Command.Dto;
using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using AutoMapper;

namespace Application.AddressService.Province.Command;

public class AddProvince : Command<Domain.Province, AddProvinceRequest>
{
    public AddProvince(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(AddProvinceRequest request)
    {
        var province = Mapper.Map<Domain.Province>(request);
        DbSet.Add(province);
        SaveChanges();
        return new Response();
    }
}