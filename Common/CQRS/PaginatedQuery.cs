using Common.BaseDto; 

namespace Common.CQRS
{
    public interface PaginatedQuery<Res, Req>
    {
        Task<PaginatedResponse<Res>> Execute(Request<Req> request);
    }
}
