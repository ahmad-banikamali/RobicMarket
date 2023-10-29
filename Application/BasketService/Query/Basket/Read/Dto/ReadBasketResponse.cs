namespace Application.BasketService.Query.Basket.Read.Dto;

public class ReadBasketResponse
{
    public int Id { get; set; }
    public string BuyerId { get; set; }
    public ICollection<BasketItemResponse> BasketItems { get; set; }
}

public class BasketItemResponse
{
    public string Name { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    
    public string Image { get; set; }
}