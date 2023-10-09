using Application.ProductService.Update.Dto;
using AutoMapper;
using Common.BaseDto;
using Common.CQRS;
using Domain;

namespace Application.ProductService.Update;

public class UpdateProduct:ICommand<UpdateProductRequest>
{
    private readonly IDatabaseContext _databaseContext;
    private readonly IMapper _mapper;

    public UpdateProduct(IDatabaseContext databaseContext,IMapper mapper)
    {
        _databaseContext = databaseContext;
        _mapper = mapper;
    }
    
    public Response Execute(Request<UpdateProductRequest> request)
    {
        _databaseContext.Products.Update(_mapper.Map<Product>(request.Data));
        _databaseContext.SaveChanges();
        return new Response();
    }
    
}