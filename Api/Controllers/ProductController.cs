using Application.ProductService.Create;
using Application.ProductService.Create.Dto;
using Application.ProductService.Delete;
using Application.ProductService.Delete.Dto;
using Application.ProductService.Read;
using Application.ProductService.Read.Dto;
using Application.ProductService.Update;
using Application.ProductService.Update.Dto;
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
        private readonly DeleteAllProducts _deleteAllProducts;

        public ProductController(
            CreateProduct createProduct,
            ReadSingleProduct readSingleProduct,
            ReadPaginatedProducts readPaginatedProducts,
            UpdateProduct updateProduct,
            DeleteProduct deleteProduct,
            DeleteAllProducts deleteAllProducts)
        {
            _createProduct = createProduct;
            _readSingleProduct = readSingleProduct;
            _readPaginatedProducts = readPaginatedProducts;
            _updateProduct = updateProduct;
            _deleteProduct = deleteProduct;
            _deleteAllProducts = deleteAllProducts;
        }

        // GET: api/Product
        [HttpGet]
        public PaginatedResponse<ReadPaginatedProductsResponse> Get(int page,int pageSize)
        {
            return _readPaginatedProducts.Execute(new Request<ReadPaginatedProductsRequest>(new ReadPaginatedProductsRequest { Skip = page,PageSize = pageSize}));
        }

        // GET: api/Product/5
        [HttpGet("{id:int}", Name = "Get")]
        public Response<ReadSingleProductResponse> Get(int id)
        {
            return _readSingleProduct.Execute(new Request<ReadSingleProductRequest>( new ReadSingleProductRequest { Id = id }));
        }

        // POST: api/Product
        [HttpPost]
        public Response Post([FromBody] CreateProductRequest value)
        {
            return _createProduct.Execute(new Request<CreateProductRequest>(value));
        }

        
        [HttpPut]
        public Response Put([FromBody] UpdateProductRequest value)
        {
            return _updateProduct.Execute(new Request<UpdateProductRequest>(value));
        }
        

        // DELETE: api/Product/5
        [HttpDelete("{id:int}")]
        public Response Delete(int id)
        {
            return _deleteProduct.Execute(new Request<DeleteProductRequest>(new DeleteProductRequest{Id = id}));
        }
    

        // DELETE: api/Product 
        [HttpDelete]
        public Response Delete()
        {
            return _deleteAllProducts.Execute();
        }
    }
}