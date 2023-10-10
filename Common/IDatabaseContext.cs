using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Common
{
    public interface IDatabaseContext
    {

        EntityEntry<Product> ProductEntityEntry(Product product);
        EntityEntry<Comment> CommentEntityEntry(Comment comment);
        DbSet<Product> Products { get; } 
        DbSet<Comment> Comments { get;  }
        
        int SaveChanges();
    }
}
