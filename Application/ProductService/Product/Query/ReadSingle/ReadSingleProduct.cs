using Application.ProductService.Product.Query.ReadSingle.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Microsoft.EntityFrameworkCore;

namespace Application.ProductService.Product.Query.ReadSingle
{
    public class ReadSingleProduct : Query<Domain.Product,ReadSingleProductRequest, ReadSingleProductResponse>
    {
        public ReadSingleProduct(IDatabaseContext database, IMapper mapper) : base(database, mapper)
        {
        }

        public override Response<ReadSingleProductResponse> Execute(ReadSingleProductRequest request)
        {
            var product = DbSet
                .Include(x=>x.ImageUrls)
                .Include(x=>x.Colors)
                .Include(x=>x.GuaranteeTypes)
                .Include(x => x.Comments)
                .ThenInclude(x=>x.AnswerComments)
                .ThenInclude(x=>x.ApplicationUser)
                .Include(x=>x.Comments)
                .ThenInclude(x=>x.ApplicationUser) 
                .Include(x=>x.ProductDetails)
                .ThenInclude(x=>x.MinorKey)
                .ThenInclude(x=>x.MajorKey)
                .FirstOrDefault(p => p.Id == request.Id);
            
 

            if(product!=null)
                product.Comments = product.Comments.Where(x => x.ParentCommentId == null).ToList();

            var data = Mapper.Map<ReadSingleProductResponse>(product);
            return new Response<ReadSingleProductResponse> { Data = data, };
        }
    }
}