﻿using Application.ProductService.Query.ReadSingleProduct.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Common.Extension;
using Microsoft.EntityFrameworkCore;

namespace Application.ProductService.Query.ReadSingleProduct
{
    public class ReadSingleProduct : Query<ReadSingleProductRequest, ReadSingleProductResponse>
    {
        public ReadSingleProduct(IDatabaseContext database, IMapper mapper) : base(database, mapper)
        {
        }

        public override Response<ReadSingleProductResponse> Execute(ReadSingleProductRequest request)
        {
            var product = DatabaseContext.Products 
                .Include(x => x.Comments)
                .ThenInclude(x=>x.AnswerComments)   
                .FirstOrDefault(p => p.Id == request.Id);
            
 

            if(product!=null)
                product.Comments = product.Comments.Where(x => x.ParentCommentId == null).ToList();

            var data = Mapper.Map<ReadSingleProductResponse>(product);
            return new Response<ReadSingleProductResponse> { Data = data, };
        }
    }
}