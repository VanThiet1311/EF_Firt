using Microsoft.EntityFrameworkCore;
using EF_ENTITY.Entities.Base;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EF_ENTITY.EF_DBContext
{
    public abstract class BaseDbContext : DbContext
    {
        protected BaseDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<EntityBase>();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Global filter: chỉ lấy các entity chưa bị xóa mềm
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(EntityBase).IsAssignableFrom(entityType.ClrType))
                {
                    var method = typeof(BaseDbContext)
                        .GetMethod(nameof(SetSoftDeleteFilter), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)!
                        .MakeGenericMethod(entityType.ClrType);

                    method.Invoke(null, new object[] { modelBuilder });
                }
            }

            base.OnModelCreating(modelBuilder);
        }

        private static void SetSoftDeleteFilter<TEntity>(ModelBuilder modelBuilder)
            where TEntity : EntityBase
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
