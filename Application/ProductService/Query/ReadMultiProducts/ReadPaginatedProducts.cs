using Application.ProductService.Query.ReadMultiProducts.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Common.Extension;

namespace Application.ProductService.Query.ReadMultiProducts;

public class ReadPaginatedProducts : PaginatedQuery<ReadPaginatedProductsRequest,ReadPaginatedProductsResponse>
{ 
    public ReadPaginatedProducts(IDatabaseContext context,IMapper mapper) : base(context,mapper)
    {
    }
    
    public override PaginatedResponse<ReadPaginatedProductsResponse> Execute(ReadPaginatedProductsRequest request)
    {
        var products = DatabaseContext.Products.PagedResult(request.Skip, request.PageSize, out var pageCount);
        return new PaginatedResponse<ReadPaginatedProductsResponse>
        {
            Data =products.Select(product => Mapper.Map<ReadPaginatedProductsResponse>(product)),
            ItemCountInPage = pageCount,
            PageIndex = request.Skip,
            MaxItemsPerPage = request.PageSize
        };
    }
}