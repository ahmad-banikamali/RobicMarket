using Application.AddressService.Province.Query.ReadMultiple.Dto; 
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;

namespace Application.AddressService.Province.Query;

public class ReadMultipleProvinces : PaginatedQuery<Domain.Province,ReadMultipleProvincesRequest,ReadMultipleProvincesResponse>
{
    public ReadMultipleProvinces(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override PaginatedResponse<ReadMultipleProvincesResponse> Execute(ReadMultipleProvincesRequest request)
    {
        return new PaginatedResponse<ReadMultipleProvincesResponse>()
        { 
            Data = Mapper.Map<ICollection<ReadMultipleProvincesResponse>>(DbSet),
            Message = {"no pagination"}
        };
    }
}