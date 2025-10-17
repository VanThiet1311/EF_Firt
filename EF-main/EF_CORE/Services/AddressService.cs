using Microsoft.EntityFrameworkCore;
using MiniEfApi.Data;
using Model = MiniEfApi.Models;   


namespace MiniEfApi.Services
{
    public class AddressService
    {
        private readonly AppDbContext _context;

        public AddressService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Address>> GetAddressesAsync(){
            return await _context.Address
                                 .Include(a => a.Customer) 
                                 .ToListAsync();
        }

        public async Task<Address?> GetByIdAddressAsync(int id)
        {
            return await _context.Address
                                 .Include(a => a.Customer)
                                 .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Address> CreateAddressAsync(Model.Address model)
        {
            var entity = new Address
            {
                Road = model.Road,
                CustomerId = model.CustomerId
            };

            await _context.Address.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Address?> UpdateAddressAsync(int id, Model.Address model)
        {
            var entity = await _context.Address.FirstOrDefaultAsync(a => a.Id == id);
            if (entity == null) return null;

            entity.Road = model.Road;
            entity.CustomerId = model.CustomerId;

            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAddressAsync(int id)
        {
            var entity = await _context.Address.FirstOrDefaultAsync(a => a.Id == id);
            if (entity == null) return false;

            _context.Address.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
