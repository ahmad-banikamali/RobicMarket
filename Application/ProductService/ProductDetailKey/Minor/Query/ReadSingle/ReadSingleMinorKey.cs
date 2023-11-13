using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using Application.ProductService.Product.Query.ReadMultiple.Dto;
using Application.ProductService.ProductDetailKey.Minor.Query.ReadSingle.Dto;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.ProductService.ProductDetailKey.Minor.Query.ReadSingle;

public class ReadSingleMinorKey : Query<MinorKey,ReadSingleMinorKeyRequest, ReadSingleMinorKeyResponse>
{
    public ReadSingleMinorKey(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response<ReadSingleMinorKeyResponse> Execute(ReadSingleMinorKeyRequest request)
    {
        var minorKey = DbSet
            .Include(x => x.MajorKey)
            .First(x => x.Id == request.Id);
        return new Response<ReadSingleMinorKeyResponse>()
        {
            Data = Mapper.Map<ReadSingleMinorKeyResponse>(minorKey)
        };
    }
}