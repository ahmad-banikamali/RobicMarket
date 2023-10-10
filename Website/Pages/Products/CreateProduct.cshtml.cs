using Application.ProductService.Command.Create;
using Application.ProductService.Command.Create.Dto;
using Common.BaseDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; 

namespace Website.Pages.Products
{
    public class CreateProductModel : PageModel
    {
        private readonly CreateProduct _createProduct;

        [BindProperty]
        public CreateProductRequest CreateProductRequest { get; set; }

        public CreateProductModel(CreateProduct createProduct)
        {
            this._createProduct = createProduct;
        }

        public void OnGet()
        {
            
        }


        public  Response OnPost() {
            return  _createProduct.Execute(CreateProductRequest);
        }
    }
}
