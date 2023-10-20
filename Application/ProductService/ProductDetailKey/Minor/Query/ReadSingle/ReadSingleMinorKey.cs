﻿using Application.ProductService.Product.Query.ReadMultiple.Dto;
using Application.ProductService.ProductDetailKey.Minor.Query.ReadSingle.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Microsoft.EntityFrameworkCore;

namespace Application.ProductService.ProductDetailKey.Minor.Query.ReadSingle;

public class ReadSingleMinorKey : Query<ReadSingleMinorKeyRequest, ReadSingleMinorKeyResponse>
{
    public ReadSingleMinorKey(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response<ReadSingleMinorKeyResponse> Execute(ReadSingleMinorKeyRequest request)
    {
        var minorKey = DatabaseContext.MinorKeys
            .Include(x => x.MajorKey)
            .First(x => x.Id == request.Id);
        return new Response<ReadSingleMinorKeyResponse>()
        {
            Data = Mapper.Map<ReadSingleMinorKeyResponse>(minorKey)
        };
    }
}