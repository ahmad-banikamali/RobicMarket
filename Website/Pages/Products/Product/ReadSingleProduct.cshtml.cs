using Application.BasketService.Command.Create.BasketItem;
using Application.BasketService.Command.Dto;
using Application.ProductService.Product.Query.ReadSingle;
using Application.ProductService.Product.Query.ReadSingle.Dto;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Website.Utils;

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

        public void OnPostAddItemToBasket(int id)
        {
            var response = _readSingleProduct.Execute(new ReadSingleProductRequest { Id = id });
            ReadSingleProductResponse = response.Data;

            AddBasketItemToBasketRequest.BuyerId = this.GetBuyerId(_userManager); 
            AddBasketItemToBasketRequest.ColorId = 2; 
            AddBasketItemToBasketRequest.GuaranteeTypeId = 1; 
            _addBasketItemToBasket.Execute(AddBasketItemToBasketRequest);
          
        } 
    }
}