using Application.ProductService.ProductDetailKey.Major.Query.ReadMultiple.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Common.Extension;
using Domain;

namespace Application.ProductService.ProductDetailKey.Major.Query.ReadMultiple;

public class ReadMultipleMajorKeys : PaginatedQuery<ReadMultMajorKeysRequest, ReadMultiMajorKeysResponse>
{
    public ReadMultipleMajorKeys(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override PaginatedResponse<ReadMultiMajorKeysResponse> Execute(ReadMultMajorKeysRequest request)
    {
        return new PaginatedResponse<ReadMultiMajorKeysResponse>()
        {
            Data = Mapper.Map<List<MajorKey>, List<ReadMultiMajorKeysResponse>>(
                DatabaseContext.MajorKeys.PagedResult(request.PageNumber, request.PageSize).ToList()
            )
        };
    }
}