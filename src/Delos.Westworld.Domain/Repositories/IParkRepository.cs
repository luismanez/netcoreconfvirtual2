using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Delos.Westworld.Domain.Repositories
{
    public interface IParkRepository
    {
        Task<IEnumerable<Park>> GetParks();
        Task<Park> GetParkById(Guid id);
    }
}