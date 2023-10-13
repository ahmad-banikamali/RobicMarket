using Application.ProductService.Product.Command.Delete.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;

namespace Application.ProductService.Product.Command.Delete;

public class DeleteProduct : Command<DeleteProductRequest>
{ 
    public DeleteProduct(IDatabaseContext context, IMapper mapper) : base(context,mapper)
    { 
    }

    public override Response Execute(DeleteProductRequest request)
    {
        var product = DatabaseContext.Products.FirstOrDefault(x => x.Id == request.Id);
        if (product == null)
        {
            return new Response
            {
                IsSuccess = false
            };
        }

        DatabaseContext.Products.Remove(product);
        DatabaseContext.SaveChanges();
        return new Response();
    }
}