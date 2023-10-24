using AutoMapper;
using Common.BaseDto;
using Microsoft.EntityFrameworkCore;

namespace Common.CQRS
{
    public abstract class Query<TEntity, TRequest, TResponse> where TEntity : class
    {
        protected readonly IMapper Mapper;
        protected readonly IQueryable<TEntity> DbSet;

        protected Query(IDatabaseContext databaseContext, IMapper mapper, bool isTacked = false)
        {
            Mapper = mapper;
            var dbSet = databaseContext.Set<TEntity>();
            DbSet = isTacked ? dbSet.AsTracking() : dbSet.AsNoTracking();
        }

        public abstract Response<TResponse> Execute(TRequest request);
    }
}