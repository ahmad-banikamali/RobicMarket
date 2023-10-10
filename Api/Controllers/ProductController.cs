using Application.ProductService.Command.Create;
using Application.ProductService.Command.Create.Dto;
using Application.ProductService.Command.Delete;
using Application.ProductService.Command.Delete.Dto;
using Application.ProductService.Command.Update;
using Application.ProductService.Command.Update.Dto;
using Application.ProductService.Query.ReadMultiProducts;
using Application.ProductService.Query.ReadMultiProducts.Dto;
using Application.ProductService.Query.ReadSingleProduct;
using Application.ProductService.Query.ReadSingleProduct.Dto;
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
        private readonly ReadPaginatedProducts _readPaginatedProducts;
        private readonly UpdateProduct _updateProduct;
        private readonly DeleteProduct _deleteProduct; 

        public ProductController(
            CreateProduct createProduct,
            ReadSingleProduct readSingleProduct,
            ReadPaginatedProducts readPaginatedProducts,
            UpdateProduct updateProduct,
            DeleteProduct deleteProduct)
        {
            _createProduct = createProduct;
            _readSingleProduct = readSingleProduct;
            _readPaginatedProducts = readPaginatedProducts;
            _updateProduct = updateProduct;
            _deleteProduct = deleteProduct; 
        }

        // GET: api/Product
        [HttpGet]
        public PaginatedResponse<ReadPaginatedProductsResponse> Get([FromQuery] ReadPaginatedProductsRequest request)
        {
            return _readPaginatedProducts.Execute(request);
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