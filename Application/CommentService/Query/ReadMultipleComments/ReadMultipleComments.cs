using Application.CommentService.Query.ReadMultipleComments.Dto;
using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.CommentService.Query.ReadMultipleComments;

public class ReadMultipleComments : PaginatedQuery<Comment,ReadMultipleCommentsRequest, ReadMultipleCommentsResponse>
{
    public ReadMultipleComments(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override PaginatedResponse<ReadMultipleCommentsResponse> Execute(ReadMultipleCommentsRequest request)
    {
        var productComments = DbSet
            .Include(x => x.AnswerComments)
            .Where(x => x.ProductId == request.ProductId)
            .ToList();


        return new PaginatedResponse<ReadMultipleCommentsResponse>()
        {
            Data = Mapper.Map<List<Comment>, List<ReadMultipleCommentsResponse>>(
                productComments.Where(x => x.ParentCommentId == null).ToList()),
            PageNumber = request.PageSize, 
        };
    }
}