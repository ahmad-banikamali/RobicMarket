using Common.BaseDto;
using Common.CQRS;

namespace Application.ProductService.Delete;

public class DeleteAllProducts : ICommand
{
    private readonly IDatabaseContext _context;

    public DeleteAllProducts(IDatabaseContext context)
    {
        _context = context;
    }

    public Response Execute()
    {
        _context.Products.RemoveRange(_context.Products);
        _context.SaveChanges();
        return new Response();
    }
}