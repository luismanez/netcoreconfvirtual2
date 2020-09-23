using System;
using System.Threading.Tasks;
using Delos.Westworld.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Delos.Westworld.ParksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParksController : ControllerBase
    {
        private readonly ILogger<ParksController> _logger;
        private readonly IParkRepository _parkRepository;
        private readonly IHostRepository _hostRepository;

        public ParksController(ILogger<ParksController> logger,
            IParkRepository parkRepository, 
            IHostRepository hostRepository)
        {
            _logger = logger;
            _parkRepository = parkRepository;
            _hostRepository = hostRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetParks()
        {
            _logger.LogDebug("Getting All Parks...");

            var parks = await _parkRepository.GetParks();

            return Ok(parks);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPark(Guid id)
        {
            var park = await _parkRepository.GetParkById(id);

            return Ok(park);
        }

        [HttpGet("{id:guid}/hosts")]
        public async Task<IActionResult> GetHostsInPark(Guid id)
        {
            var hosts = await _hostRepository.GetHostsInPark(id);

            return Ok(hosts);
        }
    }
}
