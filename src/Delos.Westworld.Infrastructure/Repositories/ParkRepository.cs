using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Delos.Westworld.Domain;
using Delos.Westworld.Domain.Repositories;
using Delos.Westworld.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Delos.Westworld.Infrastructure.Repositories
{
    public class ParkRepository: IParkRepository
    {
        private readonly WestworldDbContext _context;

        public ParkRepository(WestworldDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Park>> GetParks()
        {
            var data = await _context.Parks.AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<Park> GetParkById(Guid id)
        {
            var park = await _context.Parks.FirstOrDefaultAsync(p => p.Id.Equals(id));

            return park;
        }
    }
}