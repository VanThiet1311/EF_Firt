
using Microsoft.EntityFrameworkCore;
using MiniEfApi.Data;
using Model = MiniEfApi.Models;   

namespace MiniEfApi.Services
{
    public class CustomerService
    {
        private readonly AppDbContext _context;
        public CustomerService(AppDbContext context)
        {
            _context = context;
        }
        // GET ALL CUSTOMERS
        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }
        //  GET DETAIL CUSTOMER
        public async Task<Customer?> GetByIdCustomerAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        //  CREATE CUSTOMER
        public async Task<Customer> CreateCustomerAsync(Model.Customer model)
        {
            var entity = new Customer
            {
                Name = model.Name,
                Email = model.Email
            };

            await _context.Customers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        // UPDATE CUSTOMER
        public async Task<Customer> UpdateCustomerAsync(int id, Model.Customer model)
        {
            var entity = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (entity == null) return null;

            entity.Name = model.Name;
            entity.Email = model.Email;

            await _context.SaveChangesAsync();
            return entity;
        }

        // DELETE CUSTOMER
        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (entity == null) return false;

           _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
