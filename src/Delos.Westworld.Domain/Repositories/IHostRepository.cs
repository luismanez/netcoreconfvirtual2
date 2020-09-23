using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Delos.Westworld.Domain.Repositories
{
    public interface IHostRepository
    {
        Task<IEnumerable<Host>> GetHostsInPark(Guid parkId);
        Task<Host> GetHost(Guid id);
    }
}