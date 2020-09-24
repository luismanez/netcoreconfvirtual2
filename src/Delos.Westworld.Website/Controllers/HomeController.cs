using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Delos.Westworld.Website.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Delos.Westworld.Website.Models;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Client;

namespace Delos.Westworld.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IParksApiClient _parksApiClient;

        public HomeController(ILogger<HomeController> logger, 
            IParksApiClient parksApiClient)
        {
            _logger = logger;
            _parksApiClient = parksApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var parks = await _parksApiClient.GetParks();

            return View(parks);
        }

        public async Task<IActionResult> Park(Guid id)
        {
            var park = await _parksApiClient.GetPark(id);
            var hosts = await _parksApiClient.GetHostsInPark(id);
            park.Hosts = hosts.ToList();

            return View(park);
        }

        public async Task<IActionResult> Repair(Guid id)
        {
            try
            {
                var host = await _parksApiClient.RepairHost(id);

                return RedirectToAction("Park", new { id = host.CurrentParkId });
            }
            catch (MsalUiRequiredException msalUiRequiredException)
            {
                var properties = new OpenIdConnectChallengeProperties
                {
                    RedirectUri = "https://localhost:44343"
                };

                properties.SetParameter("claims", msalUiRequiredException.Message);

                return Challenge(properties);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
