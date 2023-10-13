using Application.CommentService.Query.ReadMultipleComments.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.CommentService.Query.ReadMultipleComments;

public class ReadMultipleComments : PaginatedQuery<ReadMultipleCommentsRequest, ReadMultipleCommentsResponse>
{
    public ReadMultipleComments(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override PaginatedResponse<ReadMultipleCommentsResponse> Execute(ReadMultipleCommentsRequest request)
    {
        var productComments = DatabaseContext.Comments
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