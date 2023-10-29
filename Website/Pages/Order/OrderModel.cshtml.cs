using Application.AddressService.DefaultAddress.Query.Read;
using Application.AddressService.DefaultAddress.Query.Read.Dto;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Application.BasketService.Query.Basket.Read;
using Application.BasketService.Query.Basket.Read.Dto;
using Website.Utils;

namespace Website.Pages.Order;

public class OrderModel : PageModel
{
    private readonly ReadBasket _readBasket;
    private readonly ReadDefaultAddress _readDefaultAddress;
    public ICollection<BasketItemResponse> BasketItems { get; set; }
    public ReadDefaultAddressResponse DefaultAddress { get; set; }
    public OrderModel(ReadBasket readBasket,ReadDefaultAddress readDefaultAddress)
    {
        _readBasket = readBasket;
        _readDefaultAddress = readDefaultAddress;
    }
    
    public void OnGet()
    {
        BasketItems = _readBasket.Execute(new ReadBasketRequest
        {
            BuyerId = this.GetBuyerId()
        }).Data.BasketItems;

        DefaultAddress = _readDefaultAddress.Execute(new ReadDefaultAddressRequest
        {
            ApplicationUserId = this.GetUserId() ?? ""
        }).Data;
    }
}