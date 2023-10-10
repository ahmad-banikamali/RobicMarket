using AutoMapper;
using Common.BaseDto; 

namespace Common.CQRS
{
    public abstract class Query<TRequest, TResponse>
    {
        protected readonly IDatabaseContext DatabaseContext; 
        protected readonly IMapper Mapper;
        protected Query(IDatabaseContext databaseContext, IMapper mapper)
        {
            DatabaseContext = databaseContext;
            Mapper = mapper;
        }

        public abstract Response<TResponse> Execute(TRequest request);
    }
}
