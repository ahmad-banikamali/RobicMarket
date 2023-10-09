using Application.ProductService.Read.Dto;
using AutoMapper;
using Common.BaseDto;
using Common.CQRS;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductService.Read
{
    public class ReadSingleProduct : IQuery<ReadSingleProductRequest,ReadSingleProductResponse>
    {
        private readonly IDatabaseContext _database;
        private readonly IMapper _mapper;

        public ReadSingleProduct(IDatabaseContext database,IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }
        public Response<ReadSingleProductResponse> Execute(Request<ReadSingleProductRequest> request)
        {
            var product =   _database.Products.FirstOrDefault(p=>p.Id==request.Data.Id);
            var data = _mapper.Map<ReadSingleProductResponse>(product);
            return new Response<ReadSingleProductResponse> {
                Data = data,
            };
        }
    }
}
