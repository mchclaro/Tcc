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
    public class ProductRepository : IProductRepository
    {
        readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product.Id;
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);

            if (product == null)
                return;

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var res = await _context.Products.AnyAsync(c => c.Id == id);
            return res;
        }

        public async Task<Product> Read(int id)
        {
            var res = await _context.Products
                .FirstOrDefaultAsync(c => c.Id == id);

            return res;
        }

        public async Task<IList<Product>> ReadAll()
        {
            return await _context.Products
                .Include(x => x.Business)
                .ToListAsync();
        }

        public async Task Update(int id, Product product)
        {
            var res = await _context.Products.FirstOrDefaultAsync(c => c.Id == product.Id);

            if (res == null)
                return;

            res.Name = product.Name;
            res.Description = product.Description;
            res.BusinessId = product.BusinessId;

            await _context.SaveChangesAsync();
        }
        
    }
}