using Application.ProductService.Product.Query.ReadSingle;
using Application.ProductService.Product.Query.ReadSingle.Dto;
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
            var response = _readSingleProduct.Execute(new ReadSingleProductRequest { Id = id } );
            ReadSingleProductResponse = response.Data;
        }
    }
}