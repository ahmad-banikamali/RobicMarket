using Application.ProductService.ProductDetailKey.Minor.Command.Update.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Domain;

namespace Application.ProductService.ProductDetailKey.Minor.Command.Update;

public class UpdateMinorKey : Command<UpdateMinorKeyRequest>
{
    public UpdateMinorKey(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(UpdateMinorKeyRequest request)
    {
        DatabaseContext.MinorKeys.Update(Mapper.Map<MinorKey>(request));
        return new Response();
    }
}