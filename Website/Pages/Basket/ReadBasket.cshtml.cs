using Application.BasketService.Query.Basket.Read.Dto;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Website.Utils;

namespace Website.Pages.Basket;

public class ReadBasket : PageModel
{
    private readonly Application.BasketService.Query.Basket.Read.ReadBasket _readBasket;
    private readonly UserManager<ApplicationUser> _userManager;

    public ReadBasketResponse ReadBasketResponse { get; set; }

    public ReadBasket(Application.BasketService.Query.Basket.Read.ReadBasket readBasket,
        UserManager<ApplicationUser> userManager)
    {
        _readBasket = readBasket;
        _userManager = userManager;
    }

    public void OnGet()
    {
        var readBasketResponse = _readBasket.Execute(new ReadBasketRequest
        {
            BuyerId = this.GetBuyerId(_userManager)
        }).Data;
        
        if (readBasketResponse != null)
            ReadBasketResponse = readBasketResponse;
    }
}