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
        DbSet<Basket> Baskets { get;  }
        DbSet<BasketItem> BasketItems { get;  }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductDetailItem> ProductDetailItems { get; set; }     
        
        public DbSet<MinorKey> MinorKeys { get; set; }
        public DbSet<MajorKey> MajorKeys { get; set; } 
        
        int SaveChanges();
    }
}
