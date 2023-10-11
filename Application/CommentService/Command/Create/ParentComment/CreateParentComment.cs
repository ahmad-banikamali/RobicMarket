using Application.CommentService.Command.Create.ParentComment.Dto;
using AutoMapper;
using Common;
using Common.BaseDto;
using Common.CQRS;
using Domain;

namespace Application.CommentService.Command.Create.ParentComment;

public class CreateParentComment : Command<CreateParentCommentRequest>
{
    public CreateParentComment(IDatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }


    public override Response Execute(CreateParentCommentRequest request)
    {
        var product = DatabaseContext.Products.Find(request.ProductId);
        if (product == null)
            return new Response
            {
                IsSuccess = false,
                Message = { "product not found" }
            };
        DatabaseContext.Comments.Add(Mapper.Map<Comment>(request));
        DatabaseContext.SaveChanges();
        return new Response();
    }
}