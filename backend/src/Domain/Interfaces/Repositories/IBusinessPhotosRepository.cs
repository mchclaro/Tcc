using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IBusinessPhotosRepository
    {
        Task<BusinessPhotos> Create(BusinessPhotos businessPhotos);
        Task<bool> Exists(int id);
        Task Delete(int id);
    }
}