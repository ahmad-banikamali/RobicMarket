﻿using Application.AddressService.City.Query.ReadMultiple.Dto;
using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using AutoMapper;

namespace Application.AddressService.City.Query;

public class ReadMultipleCities : PaginatedQuery<Domain.City,ReadMultipleCitiesRequest, ReadMultipleCitiesResponse>
{
    public ReadMultipleCities(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override PaginatedResponse<ReadMultipleCitiesResponse> Execute(ReadMultipleCitiesRequest request)
    {
        return new PaginatedResponse<ReadMultipleCitiesResponse>()
        {
            Data = Mapper.Map<ICollection<ReadMultipleCitiesResponse>>(
                DbSet.Where(x => x.ProvinceId == request.ProvinceId)),
            Message = { "no pagination" }
        };
    }
}