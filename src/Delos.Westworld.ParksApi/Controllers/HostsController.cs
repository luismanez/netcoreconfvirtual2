using System;
using System.Threading.Tasks;
using Delos.Westworld.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Delos.Westworld.ParksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HostsController: ControllerBase
    {
        private readonly ILogger<HostsController> _logger;
        private readonly IHostRepository _hostRepository;

        public HostsController(ILogger<HostsController> logger,
            IHostRepository hostRepository)
        {
            _logger = logger;
            _hostRepository = hostRepository;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            _logger.LogDebug($"Getting Host: {id} ...");

            var host = await _hostRepository.GetHost(id);

            if (host == null)
            {
                return NotFound($"Host with id: {id} not found.");
            }

            return Ok(host);
        }
    }
}