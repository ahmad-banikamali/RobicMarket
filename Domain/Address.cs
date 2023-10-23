using Microsoft.AspNetCore.Identity;

namespace Domain;

public class Address
{
    public int Id { get; set; }  
      
    public int CityId { get; set; }
    public City City { get; set; }

    public string FullAddress { get; set; }
    public string PostalCode { get; set; }
    public string TransfereeName { get; set; }
    public string TransfereePhone { get; set; }
     
}

public class Province
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<City> Cities { get; set; } = new List<City>();
}

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Province Province { get; set; }
    public int ProvinceId { get; set; }
}