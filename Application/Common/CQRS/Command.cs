using Application.Common.BaseDto;
using Application.Common.CQRS.Request;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.CQRS
{
    public abstract class Command<TEntity, TRequest> : BaseRequest<TRequest, Response> where TEntity : class
    {
        protected readonly DbSet<TEntity> DbSet;

        protected Command(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
        {
            DbSet = databaseContext.Set<TEntity>();
        }

        protected void SaveChanges()
        {
            DatabaseContext.SaveChanges();
        }

        protected void UnChangedState(object t)
        {
            DatabaseContext.UnChangedState(t);
        }
    }
}