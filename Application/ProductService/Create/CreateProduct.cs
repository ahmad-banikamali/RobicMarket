using Application.ProductService.Create.Dto;
using AutoMapper;
using Common.BaseDto;
using Common.CQRS;
using Domain;

namespace Application.ProductService.Create
{
    public class CreateProduct : ICommand<CreateProductRequest>
    {
        private readonly IDatabaseContext _database;
        private readonly IMapper _mapper;

        public CreateProduct(IDatabaseContext database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public Response Execute(Request<CreateProductRequest> request)
        {
            _database.Products.Add(_mapper.Map<Product>(request.Data));
            _database.SaveChanges();
            return new Response();
        }
    }
}