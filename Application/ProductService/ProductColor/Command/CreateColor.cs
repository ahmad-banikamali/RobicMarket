using System.Drawing;
using Application.ProductService.ProductColor.Command.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;

namespace Application.ProductService.ProductColor.Command;

public class CreateColor : Command<Domain.Color,CreateColorRequest>
{
    public CreateColor(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(CreateColorRequest request)
    {
        DbSet.Add(Mapper.Map<Domain.Color>(request));
        SaveChanges();
        return new Response();
    }
}