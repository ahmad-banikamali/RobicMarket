using Application.ProductService.Read.Dto;
using AutoMapper;
using Common.BaseDto;
using Common.CQRS;
using Common.Extension;
using Domain;

namespace Application.ProductService.Read;

public class ReadPaginatedProducts : IPaginatedQuery<ReadPaginatedProductsRequest,ReadPaginatedProductsResponse>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public ReadPaginatedProducts(IDatabaseContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public PaginatedResponse<ReadPaginatedProductsResponse> Execute(Request<ReadPaginatedProductsRequest> request)
    {
        var requestData = request.Data;
        var products = _context.Products.PagedResult(requestData.Skip, requestData.PageSize, out var pageCount);
        return new PaginatedResponse<ReadPaginatedProductsResponse>
        {
            Data =products.Select(product => _mapper.Map<ReadPaginatedProductsResponse>(product)),
            ItemCountInPage = pageCount,
            PageIndex = requestData.Skip,
            MaxItemsPerPage = requestData.PageSize
        };
    }
}