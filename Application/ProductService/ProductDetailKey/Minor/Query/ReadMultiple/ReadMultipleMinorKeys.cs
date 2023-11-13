using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using Application.ProductService.ProductDetailKey.Minor.Query.ReadMultiple.Dto;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.ProductService.ProductDetailKey.Minor.Query.ReadMultiple;

public class ReadMultipleMinorKeys : PaginatedQuery<MinorKey,ReadMultipleMinorKeysRequest, ReadMultipleMinorKeysResponse>
{
    public ReadMultipleMinorKeys(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override PaginatedResponse<ReadMultipleMinorKeysResponse> Execute(ReadMultipleMinorKeysRequest request)
    {
        var minorKeys =DbSet.Include(x => x.MajorKey)
            . /*PagedResult(request.PageNumber,request.PageSize).*/ToList();
        return new PaginatedResponse<ReadMultipleMinorKeysResponse>
            { Data = Mapper.Map<List<MinorKey>, List<ReadMultipleMinorKeysResponse>>(minorKeys) };
    }
}