namespace Domain;

public class ProductDetailItem
{
    public int Id { get; set; }

    public int MinorKeyId { get; set; }
    public MinorKey MinorKey { get; set; }

    public string Value { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }
}

public class MajorKey
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<MinorKey> MinorKeys { get; set; } = new List<MinorKey>();
}

public class MinorKey
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public int MajorKeyId { get; set; }
    public MajorKey MajorKey { get; set; } 
    
}