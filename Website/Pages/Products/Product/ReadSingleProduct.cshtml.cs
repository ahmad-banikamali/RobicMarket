using Application.BasketService.Command.Create.BasketItem;
using Application.BasketService.Command.Dto;
using Application.BasketService.Query.Basket.Read;
using Application.BasketService.Query.Basket.Read.Dto;
using Application.ProductService.Product.Query.ReadSingle;
using Application.ProductService.Product.Query.ReadSingle.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Website.Utils;

namespace Website.Pages.Products.Product
{
    public class ReadSingleProductModel : PageModel
    { 
        private readonly ReadBasket _readBasket;
        private readonly ReadSingleProduct _readSingleProduct;
        private readonly AddBasketItemToBasket _addBasketItemToBasket;
        public ReadSingleProductResponse? ReadSingleProductResponse { get; set; }
        
        [BindProperty]
        public AddBasketItemToBasketRequest AddBasketItemToBasketRequest { get; set; }

        public ReadSingleProductModel(
            ReadBasket readBasket,
            ReadSingleProduct readSingleProduct,
            AddBasketItemToBasket addBasketItemToBasket
        )
        {
            _readBasket = readBasket;
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
            ReadSingleProductResponse = _readSingleProduct.Execute(new ReadSingleProductRequest { Id = id }).Data; 
            var basketData = _readBasket.Execute(new ReadBasketRequest(){BuyerId = this.GetBuyerId()}).Data;  
            
            AddBasketItemToBasketRequest.BasketId = basketData.Id ; 
            AddBasketItemToBasketRequest.ColorId = 2; 
            AddBasketItemToBasketRequest.GuaranteeTypeId = 1; 
            _addBasketItemToBasket.Execute(AddBasketItemToBasketRequest);
          
        } 
    }
}