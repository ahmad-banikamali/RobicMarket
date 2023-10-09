using Application.ProductService.Read;
using Application.ProductService.Read.Dto;
using Common.BaseDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages.Products
{
    public class ReadSingleProductModel : PageModel
    {
        private readonly ReadSingleProduct _readSingleProduct;
        public ReadSingleProductResponse? ReadSingleProductResponse { get; set; }

        public ReadSingleProductModel(ReadSingleProduct readSingleProduct)
        {
            this._readSingleProduct = readSingleProduct;
        }

        public void OnGet([FromRoute] int id)
        {
            var response = _readSingleProduct.Execute(new Request<ReadSingleProductRequest>(new ReadSingleProductRequest { Id = id }) );
            ReadSingleProductResponse = response.Data;
        }
    }
}