using AutoMapper;
using Common.BaseDto; 

namespace Common.CQRS
{
    public abstract class PaginatedQuery<TReq,TRes> where TReq : PaginatedRequest
    {
        protected readonly IDatabaseContext DatabaseContext;
        protected readonly IMapper Mapper;

        protected PaginatedQuery(IDatabaseContext databaseContext, IMapper mapper)
        {
            DatabaseContext = databaseContext;
            Mapper = mapper;
        }
        public abstract PaginatedResponse<TRes> Execute(TReq request);
    }
}
    