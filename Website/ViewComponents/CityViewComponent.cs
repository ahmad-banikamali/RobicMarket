using Application.AddressService.City.Query;
using Application.AddressService.City.Query.ReadMultiple.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Website.ViewComponents;

public class CityViewComponent:ViewComponent
{
    private readonly ReadMultipleCities _readMultipleCities;

    public CityViewComponent(ReadMultipleCities readMultipleCities)
    {
        _readMultipleCities = readMultipleCities;
    }
    public IViewComponentResult  Invoke(int provinceId,Action<int> onCitySelected)
    {
        var paginatedResponse = _readMultipleCities.Execute(new ReadMultipleCitiesRequest(){ProvinceId = provinceId});
        IEnumerable<SelectListItem> cityListItems = paginatedResponse.Data.ToList().Select(x=>new SelectListItem(text:x.Name,value:x.Id.ToString()));
        ViewBag.onClick = onCitySelected;
        return View(cityListItems);
    }
}