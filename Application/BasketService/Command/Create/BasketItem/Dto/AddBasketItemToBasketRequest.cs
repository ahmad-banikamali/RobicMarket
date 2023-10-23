namespace Application.BasketService.Command.Dto;

public class AddBasketItemToBasketRequest
{
    public string BuyerId { get; set; }
    public int ProductId { get; set; } 
    
    public int Price { get; set; }
    
    public string Image { get; set; }
    public int GuaranteeTypeId { get; set; } 
    public int ColorId { get; set; }
    public int Count { get; set; }
}