using Application.ProductService.Create.Dto;
using AutoMapper;
using Common.BaseDto;
using Common.CQRS;
using Domain;

namespace Application.ProductService.Create
{
    public class CreateProduct : Command<CreateProductRequest>
    {
        private readonly IDatabaseContext database;
        private readonly IMapper mapper;

        public CreateProduct(IDatabaseContext database,IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public async Task<Response> Execute(Request<CreateProductRequest> request)
        {
           await database.Products.AddAsync(mapper.Map<Product>(request()));
           database.SaveChanges();
           return new Response();
        }
    }

    
}
