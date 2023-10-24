using Microsoft.AspNetCore.Mvc;

namespace Website.ViewComponents;

public class CityViewComponent:ViewComponent
{
    public IViewComponentResult  Invoke()
    { 
        return View();
    }
}