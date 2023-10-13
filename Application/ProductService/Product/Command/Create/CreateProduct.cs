using Application.ProductService.Product.Command.Create.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;

namespace Application.ProductService.Product.Command.Create
{
    public class CreateProduct : Command<CreateProductRequest>
    { 
      
        public CreateProduct(IDatabaseContext database, IMapper mapper) : base(database,mapper)
        {  
        }

        public override Response Execute(CreateProductRequest request)
        {
            DatabaseContext.Products.Add(Mapper.Map<Domain.Product>(request));
            DatabaseContext.SaveChanges();
            return new Response();
        }
    }
}