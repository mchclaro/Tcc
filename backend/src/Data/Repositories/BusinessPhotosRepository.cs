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
    public class BusinessPhotosRepository : IBusinessPhotosRepository
    {
        readonly DataContext _context;
        public BusinessPhotosRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<BusinessPhotos> Create(BusinessPhotos businessPhotos)
        {
            await _context.BusinessPhotos.AddAsync(businessPhotos);
            await _context.SaveChangesAsync();

            return businessPhotos;
        }

        public async Task Delete(int id)
        {
            var res = await _context.BusinessPhotos.FirstOrDefaultAsync(x => x.Id == id);

            if (res == null)
                return;

            _context.BusinessPhotos.RemoveRange(res);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var res = await _context.BusinessPhotos.AnyAsync(c => c.Id == id);
            return res;
        }
    }
}