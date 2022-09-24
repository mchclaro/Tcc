using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Data.Context;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class SocialMediaRepository : ISocialMediaRepository
    {
        readonly DataContext _context;
        public SocialMediaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> Create(SocialMedia socialMedia)
        {
            await _context.SocialMedias.AddAsync(socialMedia);
            await _context.SaveChangesAsync();

            return socialMedia.Id;
        }

        public async Task Delete(int id)
        {
            var res = await _context.SocialMedias.FirstOrDefaultAsync(x => x.Id == id);

            if (res == null)
                return;

            _context.SocialMedias.RemoveRange(res);

            await _context.SaveChangesAsync();
        }

        public async Task Update(SocialMedia socialMedia)
        {
            var res = await _context.SocialMedias.FirstOrDefaultAsync(c => c.Id == socialMedia.Id);

            if (res == null)
                return;

            res.Phone = socialMedia.Phone;
            res.Whatsapp = socialMedia.Whatsapp;
            res.Facebook = socialMedia.Facebook;
            res.Instagram = socialMedia.Instagram;

            await _context.SaveChangesAsync();
        }
    }
}