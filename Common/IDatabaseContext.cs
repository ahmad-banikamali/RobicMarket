using Microsoft.EntityFrameworkCore;

namespace Common
{
    public interface IDatabaseContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;  
        int SaveChanges();
    }
}
