using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using Application.ProductService.ProductDetailKey.Minor.Command.Create.Dto;
using AutoMapper;
using Domain;

namespace Application.ProductService.ProductDetailKey.Minor.Command.Create;

public class CreateMinorKey:Command<MinorKey,CreateMinorKeyRequest>
{
    public CreateMinorKey(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(CreateMinorKeyRequest request)
    {
        DbSet.Add(Mapper.Map<MinorKey>(request));
        SaveChanges();
        return new Response();
    }
}