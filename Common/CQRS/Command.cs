using Common.BaseDto; 

namespace Common.CQRS
{
    public interface Command<Req>
    {
        Task<Response> Execute(Request<Req> request);
    } 
}
