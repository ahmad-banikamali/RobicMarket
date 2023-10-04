using Common.BaseDto; 

namespace Common.CQRS
{
    public interface Query<ResponseType, RequestType>
    {

       Task<Response<ResponseType>> Execute(Request<RequestType> request);
    }
}
