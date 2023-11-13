using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using Application.ProductService.Product.Command.Create.Dto;
using AutoMapper;
using Domain;

namespace Application.ProductService.Product.Command.Create
{
    public class CreateProduct : Command<Domain.Product,CreateProductRequest>
    { 
      
        public CreateProduct(IDatabaseContext database, IMapper mapper) : base(database,mapper)
        {  
        }

        public override Response Execute(CreateProductRequest request)
        {
            var product = Mapper.Map<Domain.Product>(request);
            
            foreach (var productColor in product.Colors)
            {
                UnChangedState(productColor);
            }
            
            foreach (var productGuaranteeType in product.GuaranteeTypes)
            {
                UnChangedState(productGuaranteeType);
            }
            
   
            
            DbSet.Add(product);
            SaveChanges();
            return new Response();
        }
    }
}