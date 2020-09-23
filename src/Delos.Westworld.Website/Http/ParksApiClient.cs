using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Delos.Westworld.Domain;
using Delos.Westworld.Infrastructure.Extensions;

namespace Delos.Westworld.Website.Http
{
    public interface IParksApiClient
    {
        Task<IEnumerable<Park>> GetParks();
        Task<Park> GetPark(Guid id);
        Task<IEnumerable<Host>> GetHostsInPark(Guid id);
        Task<Host> GetHost(Guid id);
    }

    public class ParksApiClient: IParksApiClient
    {
        private readonly HttpClient _httpClient;

        public ParksApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Park>> GetParks()
        {
            var response = await _httpClient.GetAsync("api/parks");
            response.EnsureSuccessStatusCode();
            
            var parks = await response.Content.ReadAs<IEnumerable<Park>>();
            
            return parks;
        }

        public async Task<Park> GetPark(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/parks/{id}");
            response.EnsureSuccessStatusCode();

            var park = await response.Content.ReadAs<Park>();

            return park;
        }

        public async Task<IEnumerable<Host>> GetHostsInPark(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/parks/{id}/hosts");
            response.EnsureSuccessStatusCode();

            var hosts = await response.Content.ReadAs<IEnumerable<Host>>();

            return hosts;
        }

        public async Task<Host> GetHost(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/hosts/{id}");
            response.EnsureSuccessStatusCode();

            var host = await response.Content.ReadAs<Host>();

            return host;
        }
    }
}