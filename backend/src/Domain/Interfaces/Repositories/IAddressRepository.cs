using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Task<int> Create(Address address);
        Task Delete(int id);
    }
}