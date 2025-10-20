// MiniEfApi/Services/CustomerService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using EF_CORE;
using EF_ENTITY.Entities;
using MiniEfApi.Entities;
// using EF_SERVICE;

namespace MiniEfApi.Services
{
    public class CustomerService : ApplicationService<Customer>
    {
        public CustomerService(DomainService<Customer> domainService)
            : base(domainService)
        {
        }

        // 🟢 Lấy tất cả khách hàng
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync() => await GetAllAsync();

        // 🟢 Lấy khách hàng theo ID
        public async Task<Customer?> GetCustomerByIdAsync(int id) => await GetByIdAsync(id);

        // 🟢 Thêm khách hàng mới
        public async Task AddCustomerAsync(Customer model) => await AddAsync(model);

        // 🟢 Cập nhật khách hàng
        public async Task UpdateCustomerAsync(int id, Customer model) => await UpdateAsync(model);

        // 🟢 Xóa khách hàng
        public async Task DeleteCustomerAsync(Customer model) => await DeleteAsync(model);
    }
}
