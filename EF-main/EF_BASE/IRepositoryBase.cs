using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_BASE.RepositoryBase
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(System.Linq.Expressions.Expression<System.Func<T, bool>> expression);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}
