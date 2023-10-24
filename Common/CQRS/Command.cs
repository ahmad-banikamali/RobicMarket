using AutoMapper;
using Common.BaseDto;
using Microsoft.EntityFrameworkCore;

namespace Common.CQRS
{
    public abstract class Command<TEntity, TReq> where TEntity : class
    {
        private readonly IDatabaseContext _databaseContext;
        protected readonly IMapper Mapper;
        protected readonly DbSet<TEntity> DbSet;

        protected Command(IDatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            Mapper = mapper;
            DbSet = databaseContext.Set<TEntity>();
        }

        public abstract Response Execute(TReq request);

        protected void SaveChanges()
        {
            _databaseContext.SaveChanges();
        }
    }
}