using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using Application.ProductService.Product.Command.Update.Dto;
using AutoMapper;

namespace Application.ProductService.Product.Command.Update;

public class UpdateProduct:Command<Domain.Product,UpdateProductRequest>
{
 
    public UpdateProduct(IDatabaseContext databaseContext,IMapper mapper) : base(databaseContext, mapper)
    {
         
    }
    
    public override Response Execute(UpdateProductRequest request)
    {
        DbSet.Update(Mapper.Map<Domain.Product>(request));
        SaveChanges();
        return new Response();
    }
    
}