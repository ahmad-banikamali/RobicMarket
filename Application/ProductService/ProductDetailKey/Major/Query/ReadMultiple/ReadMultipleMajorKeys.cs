using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using Application.ProductService.ProductDetailKey.Major.Query.ReadMultiple.Dto;
using AutoMapper;
using Domain;

namespace Application.ProductService.ProductDetailKey.Major.Query.ReadMultiple;

public class ReadMultipleMajorKeys : PaginatedQuery<MajorKey,ReadMultMajorKeysRequest, ReadMultiMajorKeysResponse>
{
    public ReadMultipleMajorKeys(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override PaginatedResponse<ReadMultiMajorKeysResponse> Execute(ReadMultMajorKeysRequest request)
    {
        return new PaginatedResponse<ReadMultiMajorKeysResponse>()
        {
            Data = Mapper.Map<List<MajorKey>, List<ReadMultiMajorKeysResponse>>(
                DbSet.PagedResult(request.PageNumber, request.PageSize).ToList()
            )
        };
    }
}