using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<int> Create(Product product);
        Task<Product> Read(int id);
        Task<IList<Product>> ReadAll();
        Task Update(int id, Product product);
        Task<bool> Exists(int id);
        Task Delete(int id);
    }
}