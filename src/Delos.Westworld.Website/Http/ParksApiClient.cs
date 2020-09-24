using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Delos.Westworld.Domain;
using Delos.Westworld.Infrastructure.Extensions;
using Microsoft.Identity.Client;
using Microsoft.Identity.Web;

namespace Delos.Westworld.Website.Http
{
    public interface IParksApiClient
    {
        Task<IEnumerable<Park>> GetParks();
        Task<Park> GetPark(Guid id);
        Task<IEnumerable<Host>> GetHostsInPark(Guid id);
        Task<Host> GetHost(Guid id);
        Task<Host> RepairHost(Guid id);
    }

    public class ParksApiClient: IParksApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenAcquisition _tokenAcquisition;

        public ParksApiClient(HttpClient httpClient, 
            ITokenAcquisition tokenAcquisition)
        {
            _httpClient = httpClient;
            _tokenAcquisition = tokenAcquisition;
        }

        public async Task<IEnumerable<Park>> GetParks()
        {
            await SetBearerTokenForParksApi();

            var response = await _httpClient.GetAsync("api/parks");
            response.EnsureSuccessStatusCode();
            
            var parks = await response.Content.ReadAs<IEnumerable<Park>>();
            
            return parks;
        }

        public async Task<Park> GetPark(Guid id)
        {
            await SetBearerTokenForParksApi();

            var response = await _httpClient.GetAsync($"api/parks/{id}");
            response.EnsureSuccessStatusCode();

            var park = await response.Content.ReadAs<Park>();

            return park;
        }

        public async Task<IEnumerable<Host>> GetHostsInPark(Guid id)
        {
            await SetBearerTokenForParksApi();

            var response = await _httpClient.GetAsync($"api/parks/{id}/hosts");
            response.EnsureSuccessStatusCode();

            var hosts = await response.Content.ReadAs<IEnumerable<Host>>();

            return hosts;
        }

        public async Task<Host> GetHost(Guid id)
        {
            await SetBearerTokenForParksApi();

            var response = await _httpClient.GetAsync($"api/hosts/{id}");
            response.EnsureSuccessStatusCode();

            var host = await response.Content.ReadAs<Host>();

            return host;
        }

        public async Task<Host> RepairHost(Guid id)
        {
            await SetBearerTokenForParksApi();

            var response = await _httpClient.GetAsync($"api/hosts/{id}/repair");

            await CheckMultifactorAuthenticationRequiredByConditionalAccessPolicy(response);

            response.EnsureSuccessStatusCode();

            var host = await response.Content.ReadAs<Host>();

            return host;
        }

        private async Task SetBearerTokenForParksApi()
        {
            var token = await _tokenAcquisition.GetAccessTokenForUserAsync(new[] { "api://42146f37-5fe8-4734-9673-b4e07344f597/.default" });
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        private static async Task CheckMultifactorAuthenticationRequiredByConditionalAccessPolicy(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                var claims = await response.Content.ReadAsStringAsync();
                throw new MsalUiRequiredException("MFA_Required", claims);
            }
        }

        private static string GetParameter(IEnumerable<string> parameters, string parameterName)
        {
            var offset = parameterName.Length + 1;
            return parameters.FirstOrDefault(p => p.StartsWith($"{parameterName}="))?.Substring(offset)?.Trim('"');
        }
    }
}