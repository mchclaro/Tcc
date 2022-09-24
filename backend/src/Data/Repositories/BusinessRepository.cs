using Domain.Entities;
using Data.Context;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Domain.Filters;

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

        public async Task<bool> IsCnpjInUse(string cnpj)
        {
            var res = await _context.Business.AnyAsync(c => c.CNPJ == cnpj);
            return res;
        }

        public async Task Delete(int id)
        {
            var res = await _context
            .Business
            .FirstOrDefaultAsync(c => c.Id == id);

            if (res != null)
            {
                res.IsActive = false;
                res.MainImage = "";
            }

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
                .Include(x => x.SocialMedias)
                .Include(x => x.BusinessPhotos)
                .Include(x => x.Products)
                .Select(x => new Business
                {
                    Id = x.Id,
                    CNPJ = x.CNPJ,
                    SocialReson = x.SocialReson,
                    FantasyName = x.FantasyName,
                    BusinessName = x.BusinessName,
                    Priority = x.Priority,
                    Category = x.Category,
                    MainImage = x.MainImage,
                    IsActive = x.IsActive,
                    Address = new Address
                    {
                        Id = x.Address.Id,
                        Street = x.Address.Street,
                        StreetNumber = x.Address.StreetNumber,
                        ZipCode = x.Address.ZipCode,
                        Complement = x.Address.Complement,
                        District = x.Address.District,
                        City = x.Address.City,
                        State = x.Address.State
                    },
                    SocialMedias = new SocialMedia
                    {
                        Id = x.SocialMedias.Id,
                        Phone = x.SocialMedias.Phone,
                        Whatsapp = x.SocialMedias.Whatsapp,
                        Facebook = x.SocialMedias.Facebook,
                        Instagram = x.SocialMedias.Instagram
                    },
                }).Where(x => x.IsActive == true)
                .FirstOrDefaultAsync(x => x.Id == id);

            return res;
        }

        public async Task<IList<Business>> ReadAll()
        {
            return await _context.Business
               .Include(a => a.Address)
               .Include(x => x.SocialMedias)
               .Where(x => x.IsActive == true)
               .ToListAsync();
        }

        public async Task Update(Business business)
        {
            var res = await _context.Business.FindAsync(business.Id);
            if (res != null)
            {
                res.CNPJ = business.CNPJ;
                res.SocialReson = business.SocialReson;
                res.FantasyName = business.FantasyName;
                res.BusinessName = business.BusinessName;
                res.Category = business.Category;
                res.MainImage = business.MainImage;
            }

            var address = await _context.Address.FindAsync(res.AddressId);
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

            var socialMedias = await _context.SocialMedias.FindAsync(res.SocialMediaId);

            var facebook = "www.facebook.com/";
            var instagram = "www.instagram.com/";

            if (socialMedias != null)
            {
                socialMedias.Phone = business.SocialMedias.Phone;
                socialMedias.Whatsapp = business.SocialMedias.Whatsapp;
                socialMedias.Facebook = facebook + business.SocialMedias.Facebook;
                socialMedias.Instagram = instagram + business.SocialMedias.Instagram;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Business> Read(BusinessFilter filter)
        {
            IQueryable<Business> result = _context.Business
                .Include(a => a.Address)
                .Include(x => x.SocialMedias)
                .Include(x => x.BusinessPhotos);

            if (filter.Id.HasValue)
            {
                return await result.SingleOrDefaultAsync(x => x.Id == filter.Id);
            }

            return null;
        }
    }
}