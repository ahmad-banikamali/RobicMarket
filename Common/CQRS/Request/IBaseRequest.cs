namespace Common.CQRS.Request;

public interface IBaseRequest<in TRequest, out TResponse>
{
    TResponse Execute(TRequest request);
}