namespace Application.BasketService.Common.Dto;

public class BasketItemDto
{
    public int Id { get; set; } 
    public int ProductId { get; set; } 
    public int GuaranteeTypeId { get; set; } 
    public int ColorId { get; set; }
    public int Count { get; set; } 
    public int BasketId { get; set; }
}