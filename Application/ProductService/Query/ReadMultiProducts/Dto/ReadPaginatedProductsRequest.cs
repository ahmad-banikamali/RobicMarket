namespace Application.ProductService.Query.ReadMultiProducts.Dto;

public class ReadPaginatedProductsRequest
{ 
    public int PageSize { get; set; }
    public int Skip { get; set; }
}