using Application.ProductService.Delete.Dto;
using AutoMapper;
using Common.BaseDto;
using Common.CQRS;
using Domain;

namespace Application.ProductService.Delete;

public class DeleteProduct : ICommand<DeleteProductRequest>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public DeleteProduct(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Response Execute(Request<DeleteProductRequest> request)
    {
        var product = _context.Products.FirstOrDefault(x => x.Id == request.Data.Id);
        if (product == null)
        {
            return new Response
            {
                IsSuccess = false
            };
        }

        _context.Products.Remove(product);
        _context.SaveChanges();
        return new Response();
    }
}