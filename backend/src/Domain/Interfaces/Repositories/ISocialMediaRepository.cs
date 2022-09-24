using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ISocialMediaRepository
    {
        Task<int> Create(SocialMedia socialMedia);
        Task Update(SocialMedia socialMedia);
        Task Delete(int id);
    }
}