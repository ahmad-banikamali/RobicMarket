using Application;
using Common;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Repository.DatabaseContext
{
    public class SqlServerContext:DbContext, IDatabaseContext
    {
 
        public SqlServerContext(DbContextOptions<SqlServerContext> options):base(options)
        {
            
        }

        public SqlServerContext()
        {
            
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=robicmarket;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

            }
            base.OnConfiguring(optionsBuilder);
        }
        
        public EntityEntry<Product> ProductEntityEntry(Product product) => Entry(product);
        public EntityEntry<Comment> CommentEntityEntry(Comment comment) => Entry(comment);
        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }
         
        public DbSet<ProductDetailItem> ProductDetailItems { get; set; }  
        public DbSet<MinorKey> MinorKeys { get; set; }
        public DbSet<MajorKey> MajorKeys { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        { 

            foreach (var entityType in builder.Model.GetEntityTypes())
            { 
                    builder.Entity(entityType.Name).Property<DateTime>("InsertTime").HasDefaultValue(DateTime.Now);
                    builder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
                    builder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
                    builder.Entity(entityType.Name).Property<bool>("IsRemoved").HasDefaultValue(false); 
            }
            builder.Entity<Product>()
                .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);  
             
            builder.Entity<Comment>(entity =>
            {
                entity.HasKey(x => x.Id); 
                entity.HasOne(x=> x.ParentComment)
                    .WithMany(x=> x.AnswerComments)
                    .HasForeignKey(x=> x.ParentCommentId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<MajorKey>().ToTable("MajorKeys");
            builder.Entity<MinorKey>().ToTable("MinorKeys");
            
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Modified ||
                p.State == EntityState.Added ||
                p.State == EntityState.Deleted
                );
            foreach (var item in modifiedEntries)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());

                if (entityType == null)
                    continue;

                var inserted = entityType.FindProperty("InsertTime");
                var updated = entityType.FindProperty("UpdateTime");
                var RemoveTime = entityType.FindProperty("RemoveTime");
                var IsRemoved = entityType.FindProperty("IsRemoved");
                if (item.State == EntityState.Added  )
                {
                    item.Property("InsertTime").CurrentValue = DateTime.Now;
                }
                if (item.State == EntityState.Modified  )
                {
                    item.Property("UpdateTime").CurrentValue = DateTime.Now;
                }

                if (item.State == EntityState.Deleted)
                {
                    item.Property("RemoveTime").CurrentValue = DateTime.Now;
                    item.Property("IsRemoved").CurrentValue = true;
                    item.State = EntityState.Modified;
                }
            }
            return base.SaveChanges();
        }

    }
}
