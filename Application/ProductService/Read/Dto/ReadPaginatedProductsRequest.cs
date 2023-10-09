namespace Application.ProductService.Read.Dto;

public class ReadPaginatedProductsRequest
{ 
    public int PageSize { get; set; }
    public int Skip { get; set; }
}