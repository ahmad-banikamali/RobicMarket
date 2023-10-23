using Application.AddressService.City.Query.ReadMultiple.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;

namespace Application.AddressService.City.Query;

public class ReadMultipleCities : PaginatedQuery<ReadMultipleCitiesRequest, ReadMultipleCitiesResponse>
{
    public ReadMultipleCities(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override PaginatedResponse<ReadMultipleCitiesResponse> Execute(ReadMultipleCitiesRequest request)
    {
        return new PaginatedResponse<ReadMultipleCitiesResponse>()
        {
            Data = Mapper.Map<ICollection<ReadMultipleCitiesResponse>>(
                DatabaseContext.City.Where(x => x.ProvinceId == request.ProvinceId)),
            Message = { "no pagination" }
        };
    }
}