using System.Drawing;
using Application.ProductService.ProductColor.Command.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;

namespace Application.ProductService.ProductColor.Command;

public class CreateColor : Command<CreateColorRequest>
{
    public CreateColor(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(CreateColorRequest request)
    {
        DatabaseContext.Colors.Add(Mapper.Map<Domain.Color>(request));
        DatabaseContext.SaveChanges();
        return new Response();
    }
}