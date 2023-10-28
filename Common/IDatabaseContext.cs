using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Common
{
    public interface IDatabaseContext
    {
        void UnChangedState(object o);
        EntityEntry Attach(object entity);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;  
        int SaveChanges();
    }
}
