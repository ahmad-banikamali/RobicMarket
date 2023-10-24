using Application.ProductService.Product.Query.ReadMultiple.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Common.Extension;

namespace Application.ProductService.Product.Query.ReadMultiple;

public class
    ReadMultipleProducts : PaginatedQuery<Domain.Product, ReadMultipleProductsRequest, ReadMultipleProductsResponse>
{
    public ReadMultipleProducts(IDatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public override PaginatedResponse<ReadMultipleProductsResponse> Execute(ReadMultipleProductsRequest request)
    {
        var products = DbSet.PagedResult(request.PageNumber, request.PageSize);
        return new PaginatedResponse<ReadMultipleProductsResponse>
        {
            Data = products.Select(product => Mapper.Map<ReadMultipleProductsResponse>(product)),
            PageNumber = request.PageNumber,
        };
    }
}