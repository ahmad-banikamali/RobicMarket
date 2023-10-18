using Application.BasketService.Command.Create.BasketItem;
using Application.BasketService.Command.Dto;
using Application.ProductService.Product.Query.ReadSingle;
using Application.ProductService.Product.Query.ReadSingle.Dto;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Website.Pages.Products.Product
{
    public class ReadSingleProductModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ReadSingleProduct _readSingleProduct;
        private readonly AddBasketItemToBasket _addBasketItemToBasket;
        public ReadSingleProductResponse? ReadSingleProductResponse { get; set; }
        
        [BindProperty]
        public AddBasketItemToBasketRequest AddBasketItemToBasketRequest { get; set; }

        public ReadSingleProductModel(
            UserManager<ApplicationUser> userManager,
            ReadSingleProduct readSingleProduct,
            AddBasketItemToBasket addBasketItemToBasket
        )
        {
            _userManager = userManager;
            _readSingleProduct = readSingleProduct;
            _addBasketItemToBasket = addBasketItemToBasket;
        }

        public void OnGet([FromRoute] int id)
        {
            var response = _readSingleProduct.Execute(new ReadSingleProductRequest { Id = id });
            ReadSingleProductResponse = response.Data;
        }

        public void OnPostAddItemToBasket()
        {
            var buyerId = "";
            //if (User.Identity != null && User.Identity.IsAuthenticated)
            if (User.Identity is { IsAuthenticated: true })
            {
                buyerId = _userManager.GetUserId(User);
            }
            else
            {
                
            }

            AddBasketItemToBasketRequest.BuyerId = buyerId; 
            //_addBasketItemToBasket.Execute(AddBasketItemToBasketRequest);
            
        }
    }
}