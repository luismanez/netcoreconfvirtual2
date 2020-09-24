using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delos.Westworld.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;

namespace Delos.Westworld.EngineeringApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HostOperationController : ControllerBase
    {
        private readonly ILogger<HostOperationController> _logger;
        private readonly IHostOperationRepository _hostOperationRepository;

        private static readonly string[] ScopeRequiredByApi = { "Engineering.FullControl" };

        public HostOperationController(ILogger<HostOperationController> logger,
            IHostOperationRepository hostOperationRepository)
        {
            _logger = logger;
            _hostOperationRepository = hostOperationRepository;
        }

        [HttpPut("repair/{id:guid}")]
        public async Task<IActionResult> Repair(Guid id)
        {
            _logger.LogDebug($"Repairing Host: {id} ...");

            HttpContext.VerifyUserHasAnyAcceptedScope(ScopeRequiredByApi);

            var host = await _hostOperationRepository.MaintenanceAndRepair(id);

            if (host == null) return NotFound($"Host with Id: {id} not found.");

            return Ok(host);
        }
    }
}
