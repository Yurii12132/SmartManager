using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using SmartManagerServer.Core.Models.Auth;
using SmartManagerServer.Core.Repositories.ActiveDirectory;
using SmartManagerServer.Infrastructure.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartManagerServer.Infrastructure.Services.Web
{
    public class HttpContextService
    {
        private readonly IActiveDirectoryRepository activeDirectoryRepository;
        private readonly AuthConfiguration authConfiguration;
        public HttpContextService(IActiveDirectoryRepository activeDirectoryRepository, IOptions<AuthConfiguration> authConfiguration)
        {
            this.activeDirectoryRepository = activeDirectoryRepository;
            this.authConfiguration = authConfiguration.Value;
        }

        public async Task<HttpContext> AddUserDataAsync(HttpContext httpContext)
        {
            UserAccount user = null;
            var token = httpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");

            // Use the access token to call a protected web API.
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                string json = await client.GetStringAsync(authConfiguration.UserInfo);
                user = JsonSerializer.Deserialize<UserAccount>(json, options);
            }
            catch (Exception e)
            {
                return httpContext;
            }

            if (user == null) return httpContext;
            var account = await activeDirectoryRepository.GetAccountByEmailAsync(user.Email);
            if (account == null) return httpContext;
            httpContext.Items.Add("userAccount", account);
            return httpContext;
        }
    }
}
