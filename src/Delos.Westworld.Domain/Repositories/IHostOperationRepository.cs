using System;
using System.Threading.Tasks;

namespace Delos.Westworld.Domain.Repositories
{
    public interface IHostOperationRepository
    {
        Task<Host> MaintenanceAndRepair(Guid id);
    }
}