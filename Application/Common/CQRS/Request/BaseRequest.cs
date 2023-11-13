using AutoMapper;

namespace Application.Common.CQRS.Request;

public abstract class BaseRequest<TRequest, TResponse> : IBaseRequest<TRequest, TResponse>
{
    internal readonly IDatabaseContext DatabaseContext;
    protected readonly IMapper Mapper;

    protected BaseRequest(IDatabaseContext databaseContext, IMapper mapper)
    {
        DatabaseContext = databaseContext;
        Mapper = mapper;
    }

    public abstract TResponse Execute(TRequest request);
}