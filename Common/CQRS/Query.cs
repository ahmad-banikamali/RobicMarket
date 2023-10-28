using AutoMapper;
using Common.BaseDto;
using Common.CQRS.Request;
using Microsoft.EntityFrameworkCore;

namespace Common.CQRS
{
    public abstract class Query<TEntity, TRequest, TResponse> : BaseRequest<TRequest, Response<TResponse>>
        where TEntity : class
    {
        protected readonly IQueryable<TEntity> DbSet;

        protected Query(IDatabaseContext databaseContext, IMapper mapper, bool enableTrackingData = false) : base(
            databaseContext, mapper)
        {
            DbSet = enableTrackingData
                ? databaseContext.Set<TEntity>().AsTracking()
                : databaseContext.Set<TEntity>().AsNoTracking();
        }
    }
}