using Common.BaseDto; 

namespace Common.CQRS
{
    public interface IQuery<TRequest,TResponse>
    {

      Response<TResponse> Execute(Request<TRequest> request);
    }
}
