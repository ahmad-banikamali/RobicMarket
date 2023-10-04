using Application.ProductService.Read;
using Application.ProductService.Read.Dto;
using Common.BaseDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages.Products
{
    public class ReadSingleProductModel : PageModel
    {
        private readonly ReadSingleProduct readSingleProduct;
        public ReadSingleProductResponse? ReadSingleProductResponse { get; set; }

        public ReadSingleProductModel(ReadSingleProduct readSingleProduct)
        {
            this.readSingleProduct = readSingleProduct;
        }
        public async void OnGet()
        {
            Response<ReadSingleProductResponse> response =await readSingleProduct.Execute(request: ()=>new ReadSingleProductRequest {Id = 1});
            ReadSingleProductResponse = response.Data;
        }
    }
}
