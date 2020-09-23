using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delos.Westworld.Domain;
using Delos.Westworld.Domain.Repositories;
using Delos.Westworld.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Delos.Westworld.Infrastructure.Repositories
{
    public class HostRepository: IHostRepository
    {
        private readonly WestworldDbContext _context;

        public HostRepository(WestworldDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Host>> GetHostsInPark(Guid parkId)
        {
            var data = await _context.Hosts.Where(h => h.CurrentParkId.Equals(parkId)).ToListAsync();
            return data;
        }

        public async Task<Host> GetHost(Guid id)
        {
            var host = await _context.Hosts.FirstOrDefaultAsync(h => h.Id.Equals(id));
            return host;
        }
    }
}