using Common.BaseDto; 

namespace Common.CQRS
{
    public interface IPaginatedQuery<TReq,TRes>
    {
        PaginatedResponse<TRes> Execute(Request<TReq> request);
    }
}
    