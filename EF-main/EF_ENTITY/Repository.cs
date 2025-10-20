using EF_BASE.RepositoryBase;  // nhớ import đúng namespace RepositoryBase
using MiniEfApi.Data;           // để AppDbContext

namespace EF_ENTITY
{
    public class Repository<T> : RepositoryBase<T> where T : class
    {
        public Repository(AppDbContext context)
            : base(context)
        {
        }
    }
}
