﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delos.Westworld.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Delos.Westworld.EngineeringApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HostOperationController : ControllerBase
    {
        private readonly ILogger<HostOperationController> _logger;
        private readonly IHostOperationRepository _hostOperationRepository;

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

            var host = await _hostOperationRepository.MaintenanceAndRepair(id);

            if (host == null) return NotFound($"Host with Id: {id} not found.");

            return Ok(host);
        }
    }
}