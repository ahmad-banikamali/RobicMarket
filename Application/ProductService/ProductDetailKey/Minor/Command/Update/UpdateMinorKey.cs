using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using Application.ProductService.ProductDetailKey.Minor.Command.Update.Dto;
using AutoMapper;
using Domain;

namespace Application.ProductService.ProductDetailKey.Minor.Command.Update;

public class UpdateMinorKey : Command<MinorKey,UpdateMinorKeyRequest>
{
    public UpdateMinorKey(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(UpdateMinorKeyRequest request)
    {
        DbSet.Update(Mapper.Map<MinorKey>(request));
        SaveChanges();
        return new Response();
    }
}