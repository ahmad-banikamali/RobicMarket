using Application.CommentService.Command.Create.ParentComment.Dto;
using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using AutoMapper;
using Domain;

namespace Application.CommentService.Command.Create.ParentComment;

public class CreateParentComment : Command<Comment,CreateParentCommentRequest>
{
    public CreateParentComment(IDatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }


    public override Response Execute(CreateParentCommentRequest request)
    {
        DbSet.Add(Mapper.Map<Comment>(request));
        SaveChanges();
        return new Response();
    }
}