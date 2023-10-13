using Application.ProductService.Product.Command.Update.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;

namespace Application.ProductService.Product.Command.Update;

public class UpdateProduct:Command<UpdateProductRequest>
{
 
    public UpdateProduct(IDatabaseContext databaseContext,IMapper mapper) : base(databaseContext, mapper)
    {
         
    }
    
    public override Response Execute(UpdateProductRequest request)
    {
        DatabaseContext.Products.Update(Mapper.Map<Domain.Product>(request));
        DatabaseContext.SaveChanges();
        return new Response();
    }
    
}