using Application.ProductService.ProductGuarantee.Command.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Domain;

namespace Application.ProductService.ProductGuarantee.Command;

public class CreateProductGuarantee:Command<GuaranteeType,CreateProductGuaranteeRequest>
{
    public CreateProductGuarantee(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(CreateProductGuaranteeRequest request)
    {
        DbSet.Add(Mapper.Map<GuaranteeType>(request));
        SaveChanges();
        return new Response();
    }
}