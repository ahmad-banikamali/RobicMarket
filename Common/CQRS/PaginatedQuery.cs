using AutoMapper;
using Common.BaseDto;
using Microsoft.EntityFrameworkCore;

namespace Common.CQRS
{
    public abstract class PaginatedQuery<TEntity, TPaginatedRequest, TResponse>
        where TPaginatedRequest : PaginatedRequest where TEntity : class

    {
        protected readonly IMapper Mapper;
        protected readonly IQueryable<TEntity> DbSet;

        protected PaginatedQuery(IDatabaseContext databaseContext, IMapper mapper,bool isTacked = false)
        {
            var dbSet = databaseContext.Set<TEntity>();
            DbSet = isTacked ? dbSet.AsTracking() : dbSet.AsNoTracking();
            Mapper = mapper;
        }
   

        public abstract PaginatedResponse<TResponse> Execute(TPaginatedRequest request);
    }
}