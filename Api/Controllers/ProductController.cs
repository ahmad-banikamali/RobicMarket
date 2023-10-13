using Application.ProductService.Product.Command.Create;
using Application.ProductService.Product.Command.Create.Dto;
using Application.ProductService.Product.Command.Delete;
using Application.ProductService.Product.Command.Delete.Dto;
using Application.ProductService.Product.Command.Update;
using Application.ProductService.Product.Command.Update.Dto;
using Application.ProductService.Product.Query.ReadMultiple;
using Application.ProductService.Product.Query.ReadMultiple.Dto;
using Application.ProductService.Product.Query.ReadSingle;
using Application.ProductService.Product.Query.ReadSingle.Dto;
using Common.BaseDto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CreateProduct _createProduct;
        private readonly ReadSingleProduct _readSingleProduct;
        private readonly ReadMultipleProducts _readMultipleProducts;
        private readonly UpdateProduct _updateProduct;
        private readonly DeleteProduct _deleteProduct; 

        public ProductController(
            CreateProduct createProduct,
            ReadSingleProduct readSingleProduct,
            ReadMultipleProducts readMultipleProducts,
            UpdateProduct updateProduct,
            DeleteProduct deleteProduct)
        {
            _createProduct = createProduct;
            _readSingleProduct = readSingleProduct;
            _readMultipleProducts = readMultipleProducts;
            _updateProduct = updateProduct;
            _deleteProduct = deleteProduct; 
        }

        // GET: api/Product
        [HttpGet]
        public PaginatedResponse<ReadMultipleProductsResponse> Get([FromQuery] ReadMultipleProductsRequest request)
        {
            return _readMultipleProducts.Execute(request);
        }

        // GET: api/Product/5
        [HttpGet("{id:int}", Name = "Get")]
        public Response<ReadSingleProductResponse> Get(
            int id,
            int commentPageNumber,
            int commentPageSize
        )
        {
            return _readSingleProduct.Execute(new ReadSingleProductRequest
            {
                Id = id,
                CommentPageNumber = commentPageNumber,
                CommentPageSize = commentPageSize
            });
        }

        // POST: api/Product
        [HttpPost]
        public Response Post([FromBody] CreateProductRequest request)
        {
            return _createProduct.Execute(request);
        }


        [HttpPut]
        public Response Put([FromBody] UpdateProductRequest request)
        {
            return _updateProduct.Execute(request);
        }


        // DELETE: api/Product/5
        [HttpDelete("{id:int}")]
        public Response Delete(int id)
        {
            return _deleteProduct.Execute(new DeleteProductRequest{Id = id});
        }


    
    }
}