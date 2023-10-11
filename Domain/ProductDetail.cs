namespace Domain;

public class ProductDetail
{
    public int Id { get; set; }

    public int DetailMinorKeyId { get; set; }
    public MinorKeyProductDetail MinorKeyProductDetail { get; set; }

    public string Value { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }
}

public class MajorKeyProductDetail
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<MinorKeyProductDetail> DetailMinorKeys { get; set; } = new List<MinorKeyProductDetail>();
}

public class MinorKeyProductDetail
{
    public int Id { get; set; }
    public string Key { get; set; }
    
    public int DetailMajorKeyId { get; set; }
    public MajorKeyProductDetail MajorKeyProductDetail { get; set; }

    public int ProductDetailId { get; set; }
    public ProductDetail ProductDetail { get; set; }
    
}