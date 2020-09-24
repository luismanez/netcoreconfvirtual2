using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Delos.Westworld.Domain;
using Delos.Westworld.Infrastructure.Extensions;
using Microsoft.Identity.Client;
using Microsoft.Identity.Web;

namespace Delos.Westworld.ParksApi.Http
{
    public interface IEngineeringApiClient
    {
        Task<Host> RepairAndMaintenanceHost(Guid id);
    }

    public class EngineeringApiClient : IEngineeringApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenAcquisition _tokenAcquisition;

        private static readonly string[] ScopeRequiredByApi = { "api://f7c3d572-14e2-48a5-be83-c5efef92c0f8/.default" };

        public EngineeringApiClient(HttpClient httpClient,
            ITokenAcquisition tokenAcquisition)
        {
            _httpClient = httpClient;
            _tokenAcquisition = tokenAcquisition;
        }

        public async Task<Host> RepairAndMaintenanceHost(Guid id)
        {
            await SetBearerTokenForEngineeringApi();

            var response = await _httpClient.PutAsync($"api/hostoperation/repair/{id}", null);

            response.EnsureSuccessStatusCode();

            var host = await response.Content.ReadAs<Host>();

            return host;
        }

        private async Task SetBearerTokenForEngineeringApi()
        {
            // see here about Downstream APIs and MFA + CA: https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-conditional-access-dev-guide#scenario-app-performing-the-on-behalf-of-flow
            try
            {
                var token = await _tokenAcquisition.GetAccessTokenForUserAsync(ScopeRequiredByApi);
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
            catch (MicrosoftIdentityWebChallengeUserException ex)
            {
                await _tokenAcquisition.ReplyForbiddenWithWwwAuthenticateHeaderAsync(ScopeRequiredByApi, ex.MsalUiRequiredException);
                throw;
            }
            catch (MsalUiRequiredException ex)
            {
                await _tokenAcquisition.ReplyForbiddenWithWwwAuthenticateHeaderAsync(ScopeRequiredByApi, ex);
                throw;
            }
        }
    }
}