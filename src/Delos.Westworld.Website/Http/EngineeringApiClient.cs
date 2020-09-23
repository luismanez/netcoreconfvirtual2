using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Delos.Westworld.Domain;
using Delos.Westworld.Infrastructure.Extensions;

namespace Delos.Westworld.Website.Http
{
    public interface IEngineeringApiClient
    {
        Task<Host> RepairAndMaintenanceHost(Guid id);
    }

    public class EngineeringApiClient : IEngineeringApiClient
    {
        private readonly HttpClient _httpClient;

        public EngineeringApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Host> RepairAndMaintenanceHost(Guid id)
        {
            var response = await _httpClient.PutAsync($"api/hostoperation/repair/{id}", null);
            response.EnsureSuccessStatusCode();

            var host = await response.Content.ReadAs<Host>();

            return host;
        }
    }
}