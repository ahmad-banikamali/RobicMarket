using Application.ProductService.Command.CreateProductDetailKey.MajorKey.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;

namespace Application.ProductService.Command.CreateProductDetailKey.MajorKey;

public class CreateMajorKey : Command<CreateMajorKeyRequest>
{
    public CreateMajorKey(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(CreateMajorKeyRequest request)
    {
        DatabaseContext.MajorKeys.Add(Mapper.Map<Domain.MajorKey>(request));
        DatabaseContext.SaveChanges();
        return new Response();
    }
}