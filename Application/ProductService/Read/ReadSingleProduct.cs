using Application.ProductService.Read.Dto;
using AutoMapper;
using Common.BaseDto;
using Common.CQRS;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductService.Read
{
    public class ReadSingleProduct : Query<ReadSingleProductResponse, ReadSingleProductRequest>
    {
        private readonly IDatabaseContext database;
        private readonly IMapper mapper;

        public ReadSingleProduct(IDatabaseContext database,IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public async Task<Response<ReadSingleProductResponse>> Execute(Request<ReadSingleProductRequest> request)
        {

            var y = request();
            var x = mapper.Map<Product>(y);

            var product = await database.Products.FindAsync(x);

            return new Response<ReadSingleProductResponse> {
                Data = mapper.Map<ReadSingleProductResponse>(product),
            };
        }
    }
}
