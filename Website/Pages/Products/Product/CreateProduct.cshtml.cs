using Application.ProductService.Product.Command.Create;
using Application.ProductService.Product.Command.Create.Dto;
using Application.ProductService.ProductDetailKey.Minor.Query.ReadMultiple;
using Application.ProductService.ProductDetailKey.Minor.Query.ReadMultiple.Dto;
using Common.BaseDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages.Products.Product
{
    public class CreateProductModel : PageModel
    {
        private readonly CreateProduct _createProduct;
        public PaginatedResponse<ReadMultipleMinorKeysResponse> ReadMultipleMinorKeysResponse;

        [BindProperty] public CreateProductRequest CreateProductRequest { get; set; }


        public CreateProductModel(CreateProduct createProduct, ReadMultipleMinorKeys readMultipleMinorKeys)
        {
            this._createProduct = createProduct;
            ReadMultipleMinorKeysResponse = readMultipleMinorKeys.Execute(
                    new ReadMultipleMinorKeysRequest()
                );
        }

        public void OnGet()
        {
            
        } 


        public void OnPost()
        {
            CreateProductRequest .ProductDetails = CreateProductRequest.ProductDetails.Where(x=>x.Value!=null).ToList();
            
            _createProduct.Execute(CreateProductRequest);
        }
    }
}