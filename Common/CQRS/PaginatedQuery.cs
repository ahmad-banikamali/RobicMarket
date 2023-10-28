using AutoMapper;
using Common.BaseDto;
using Common.CQRS.Request;
using Microsoft.EntityFrameworkCore;

namespace Common.CQRS
{
    public abstract class
        PaginatedQuery<TEntity, TPaginatedRequest, TResponse> : BaseRequest<TPaginatedRequest,
            PaginatedResponse<TResponse>>
        where TPaginatedRequest : PaginatedRequest where TEntity : class

    {
        protected readonly IQueryable<TEntity> DbSet;

        protected PaginatedQuery(IDatabaseContext databaseContext, IMapper mapper, bool enableTrackingData = false) :
            base(databaseContext, mapper)
        {
            DbSet = enableTrackingData
                ? databaseContext.Set<TEntity>().AsTracking()
                : databaseContext.Set<TEntity>().AsNoTracking();
        }
    }
}