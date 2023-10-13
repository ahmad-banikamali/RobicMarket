using Application.ProductService.ProductDetailKey.Major.Query.ReadSingle.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Microsoft.EntityFrameworkCore;

namespace Application.ProductService.ProductDetailKey.Major.Query.ReadSingle;

public class ReadSingleMajorKey : Query<ReadSingleMajorKeyRequest, ReadSingleMajorKeyResponse>
{
    public ReadSingleMajorKey(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response<ReadSingleMajorKeyResponse> Execute(ReadSingleMajorKeyRequest request)
    {
        var majorKey = DatabaseContext.MajorKeys
            .Include(x=>x.MinorKeys)
            
            .FirstOrDefault(y => y.Id == request.Id);

        if (majorKey == null)
            return new Response<ReadSingleMajorKeyResponse>()
            {
                IsSuccess = false,
                Message = { "wrong id" }
            };
        var x = Mapper
            .Map<ReadSingleMajorKeyResponse>(majorKey);
        x.MinorKeys = majorKey.MinorKeys.Select(y => y.Name).ToList();
        return new Response<ReadSingleMajorKeyResponse>
        {
            Data = x
        };
    }
}