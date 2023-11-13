using Application.AddressService.Province.Query.ReadMultiple.Dto;
using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using AutoMapper;

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