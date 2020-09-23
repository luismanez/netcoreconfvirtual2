using System;
using System.Threading.Tasks;
using Delos.Westworld.Domain;
using Delos.Westworld.Domain.Repositories;
using Delos.Westworld.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Delos.Westworld.Infrastructure.Repositories
{
    public class HostOperationRepository: IHostOperationRepository
    {
        private readonly WestworldDbContext _context;

        public HostOperationRepository(WestworldDbContext context)
        {
            _context = context;
        }

        public async Task<Host> MaintenanceAndRepair(Guid id)
        {
            var host = await _context.Hosts.FirstOrDefaultAsync(h => h.Id.Equals(id));

            if (host == null) return null;

            host.LastSystemReview = DateTime.Now;

            _context.Hosts.Update(host);
            await _context.SaveChangesAsync();

            return host;
        }
    }
}