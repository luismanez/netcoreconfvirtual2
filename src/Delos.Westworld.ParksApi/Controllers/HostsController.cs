using System;
using System.Threading.Tasks;
using Delos.Westworld.Domain.Repositories;
using Delos.Westworld.ParksApi.Http;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;

namespace Delos.Westworld.ParksApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HostsController: ControllerBase
    {
        private readonly ILogger<HostsController> _logger;
        private readonly IHostRepository _hostRepository;
        private readonly IEngineeringApiClient _engineeringApiClient;

        private static readonly string[] ScopeRequiredByApi = { "Parks.FullControl" };

        public HostsController(ILogger<HostsController> logger,
            IHostRepository hostRepository,
            IEngineeringApiClient engineeringApiClient)
        {
            _logger = logger;
            _hostRepository = hostRepository;
            _engineeringApiClient = engineeringApiClient;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            _logger.LogDebug($"Getting Host: {id} ...");

            HttpContext.VerifyUserHasAnyAcceptedScope(ScopeRequiredByApi);

            var host = await _hostRepository.GetHost(id);

            if (host == null)
            {
                return NotFound($"Host with id: {id} not found.");
            }

            return Ok(host);
        }

        [HttpGet("{id:guid}/repair")]
        public async Task<IActionResult> Repair(Guid id)
        {
            _logger.LogDebug($"Repairing Host: {id} ...");

            HttpContext.VerifyUserHasAnyAcceptedScope(ScopeRequiredByApi);

            // 2nd hoop from a Secured AAD Api to another secured AAD Api
            // If 2nd API requires Multifactor, and 1st not, it will cause an issue
            try
            {
                var host = await _engineeringApiClient.RepairAndMaintenanceHost(id);

                return Ok(host);
            }
            catch (MicrosoftIdentityWebChallengeUserException ex)
            {
                await HttpContext.Response.WriteAsync(ex.MsalUiRequiredException.Claims);
                return Forbid();
            }
            catch (MsalUiRequiredException ex)
            {
                await HttpContext.Response.WriteAsync(ex.Claims);
                return Forbid();
            }
        }

        private OpenIdConnectChallengeProperties PrepareForbidResponseWithClaims(string claims)
        {
            var properties = new OpenIdConnectChallengeProperties
            {
                RedirectUri = "https://localhost:44343"
            };
            properties.SetParameter("claims", claims);
            return properties;
        }
    }
}