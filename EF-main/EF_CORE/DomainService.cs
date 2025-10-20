using System.Collections.Generic;
using System.Threading.Tasks;
using EF_BASE.RepositoryBase;

namespace EF_CORE
{
    public class DomainService<T> where T : class
    {
        private readonly IRepositoryBase<T> _repository;

        public DomainService(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        // 🟢 Lấy tất cả dữ liệu
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // 🟢 Lấy theo ID
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        // 🟢 Thêm mới
        public virtual async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
        }

        // 🟢 Cập nhật
        public virtual async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _repository.SaveChangesAsync();
        }

        // 🟢 Xóa
        public virtual async Task DeleteAsync(T entity)
        {
            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
        }
    }
}
