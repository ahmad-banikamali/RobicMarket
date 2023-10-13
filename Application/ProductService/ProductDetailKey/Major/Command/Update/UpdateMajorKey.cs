using Application.ProductService.ProductDetailKey.Major.Command.Update.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Domain;

namespace Application.ProductService.ProductDetailKey.Major.Command.Update;

public class UpdateMajorKey : Command<UpdateMajorKeyRequest>
{
    public UpdateMajorKey(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(UpdateMajorKeyRequest request)
    {
        DatabaseContext.MajorKeys.Update(Mapper.Map<MajorKey>(request));
        DatabaseContext.SaveChanges();
        return new Response();
    }
}