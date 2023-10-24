using Application.ProductService.ProductDetailKey.Major.Command.Update.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Domain;

namespace Application.ProductService.ProductDetailKey.Major.Command.Update;

public class UpdateMajorKey : Command<MajorKey,UpdateMajorKeyRequest>
{
    public UpdateMajorKey(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(UpdateMajorKeyRequest request)
    {
        DbSet.Update(Mapper.Map<MajorKey>(request));
        SaveChanges();
        return new Response();
    }
}