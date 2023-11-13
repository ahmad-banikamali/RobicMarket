using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using Application.ProductService.ProductDetailKey.Major.Command.Create.Dto;
using AutoMapper;

namespace Application.ProductService.ProductDetailKey.Major.Command.Create;

public class CreateMajorKey : Command<Domain.MajorKey,CreateMajorKeyRequest>
{
    public CreateMajorKey(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(CreateMajorKeyRequest request)
    {
        DbSet.Add(Mapper.Map<Domain.MajorKey>(request));
        SaveChanges();
        return new Response();
    }
}