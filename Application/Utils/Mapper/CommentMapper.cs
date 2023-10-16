using Application.CommentService.Command.Create.AnswerComment.Dto;
using Application.CommentService.Command.Create.ParentComment.Dto;
using Application.CommentService.Query.ReadMultipleComments.Dto;
using Application.ProductService.Product.Query.ReadSingle.Dto;
using AutoMapper;
using Domain;

namespace Application.Utils.Mapper
{
    public class CommentMapper : Profile
    {
        public CommentMapper()
        {
            CreateMap<Comment, CreateParentCommentRequest>().ReverseMap();
            CreateMap<Comment, CreateAnswerCommentRequest>().ReverseMap();
            CreateMap<Comment, CommentWithProduct>().ReverseMap();
            CreateMap<Comment, CommentWithProduct>().ReverseMap(); 
            CreateMap<Comment, ReadMultipleCommentsResponse>().ReverseMap();
        }
    }
}