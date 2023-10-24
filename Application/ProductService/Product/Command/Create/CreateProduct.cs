using Application.ProductService.Product.Command.Create.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;

namespace Application.ProductService.Product.Command.Create
{
    public class CreateProduct : Command<Domain.Product,CreateProductRequest>
    { 
      
        public CreateProduct(IDatabaseContext database, IMapper mapper) : base(database,mapper)
        {  
        }

        public override Response Execute(CreateProductRequest request)
        {
            DbSet.Add(Mapper.Map<Domain.Product>(request));
            SaveChanges();
            return new Response();
        }
    }
}