using Application.ProductService.Create;
using Application.ProductService.Create.Dto;
using Common.BaseDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; 

namespace Website.Pages.Products
{
    public class CreateProductModel : PageModel
    {
        private readonly CreateProduct createProduct;

        [BindProperty]
        public CreateProductRequest CreateProductRequest { get; set; }

        public CreateProductModel(CreateProduct createProduct)
        {
            this.createProduct = createProduct;
        }

        public void OnGet()
        {
            
        }


        public async void OnPost() {
            Response response = await createProduct.Execute(() => CreateProductRequest);
            
        }
    }
}
