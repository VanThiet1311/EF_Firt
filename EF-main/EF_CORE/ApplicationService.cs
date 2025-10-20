// EF_SERVICE/ApplicationService.cs
using EF_CORE;

public class ApplicationService<T> where T : class
{
    protected readonly DomainService<T> _domainService;
    public ApplicationService(DomainService<T> domainService)
    {
        _domainService = domainService;
    }
    public async Task<IEnumerable<T>> GetAllAsync() => await _domainService.GetAllAsync();
    public async Task<T?> GetByIdAsync(int id) => await _domainService.GetByIdAsync(id);
    public async Task AddAsync(T entity) => await _domainService.AddAsync(entity);
    public async Task UpdateAsync(T entity) => await _domainService.UpdateAsync(entity);
    public async Task DeleteAsync(T entity) => await _domainService.DeleteAsync(entity);
}
