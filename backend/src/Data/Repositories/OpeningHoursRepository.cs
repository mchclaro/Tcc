using Domain.Entities;
using Data.Context;
using Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    public class OpeningHoursRepository : IOpeningHoursRepository
    {
        readonly DataContext _context;
        public OpeningHoursRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(OpeningHours openingHours)
        {
            await _context.OpeningHours.AddAsync(openingHours);
            await _context.SaveChangesAsync();
        }
    }
}