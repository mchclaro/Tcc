using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IBusinessRepository
    {
        Task<int> Create(Business business);
        Task<Business> Read(int id);
        Task<IList<Business>> ReadAll();
        Task Update(Business business);
        Task<bool> Exists(int id);
        Task Delete(int id);
    }
}