using Microsoft.EntityFrameworkCore;
using EF_ENTITY.EF_DBContext;
namespace MiniEfApi.Data
{
    public class AppDbContext : BaseDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }

    }
}
