using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public interface IDatabaseContext
    {
        DbSet<Product> Products { get; } 
        DbSet<Comment> Comments { get;  }
        
        int SaveChanges();
    }
}
