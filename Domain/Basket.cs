namespace Domain;

public class Basket
{
    public int Id { get; set; }
    public string BuyerId { get; set; }
    public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
}

public class BasketItem
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public int ProductId { get; set; }
    public GuaranteeType GuaranteeType { get; set; }
    public int GuaranteeTypeId { get; set; }
    public Color Color { get; set; }
    public int ColorId { get; set; }
    public int Count { get; set; }
    public Basket Basket { get; set; }
    public int BasketId { get; set; }
}