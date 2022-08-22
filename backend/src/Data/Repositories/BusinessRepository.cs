using Domain.Entities;
using Data.Context;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class BusinessRepository : IBusinessRepository
    {
        readonly DataContext _context;
        public BusinessRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Business business)
        {
            await _context.Business.AddAsync(business);
            await _context.SaveChangesAsync();

            return business.Id;
        }

        public async Task Delete(int id)
        {
            var business = _context.Address.OrderBy(e => e.Id)
                                            .Include(e => e.Business).First();

            if (business == null)
                return;

            _context.Address.Remove(business);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var res = await _context.Business.AnyAsync(c => c.Id == id);
            return res;
        }

        public async Task<Business> Read(int id)
        {

            var res = await _context.Business
                .Include(x => x.Address)
                .Select(x => new Business
                {
                    Id = x.Id,
                    CNPJ = x.CNPJ,
                    SocialReson = x.SocialReson,
                    FantasyName = x.FantasyName,
                    BusinessName = x.BusinessName,
                    Priority = x.Priority,
                    Category = x.Category,
                    Address = new Address
                    {
                        Street = x.Address.Street,
                        StreetNumber = x.Address.StreetNumber,
                        ZipCode = x.Address.ZipCode,
                        Complement = x.Address.Complement,
                        District = x.Address.District,
                        City = x.Address.City,
                        State = x.Address.State
                    },
                }).FirstOrDefaultAsync(x => x.Id == id);

            return res;
        }

        public async Task<IList<Business>> ReadAll()
        {
             return await _context.Business
                .Include(a => a.Address)
                .ToListAsync();
        }

        public async Task Update(Business business)
        {
            var res = await _context.Business.FirstOrDefaultAsync(c => c.Id == business.Id);

            if (res != null)
            {
                res.CNPJ = business.CNPJ;
                res.SocialReson = business.SocialReson;
                res.FantasyName = business.FantasyName;
                res.BusinessName = business.BusinessName;
                res.Category = business.Category;
            }

            var address = await _context.Address.FirstOrDefaultAsync(c => c.Id == business.Id);
            if (address != null)
            {
                address.Street = business.Address.Street;
                address.StreetNumber = business.Address.StreetNumber;
                address.ZipCode = business.Address.ZipCode;
                address.District = business.Address.District;
                address.Complement = business.Address.Complement;
                address.City = business.Address.City;
                address.State = business.Address.State;
            }

            await _context.SaveChangesAsync();
        }
        
    }
}