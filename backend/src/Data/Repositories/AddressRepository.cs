using Domain.Entities;
using Data.Context;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        readonly DataContext _context;
        public AddressRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Address address)
        {
            await _context.Address.AddAsync(address);
            await _context.SaveChangesAsync();

            return address.Id;
        }

        public async Task Delete(int id)
        {
            var address = await _context.Address.FirstOrDefaultAsync(c => c.Id == id);

            if (address == null)
                return;

            _context.Address.Remove(address);

            await _context.SaveChangesAsync();
        }
    }
}