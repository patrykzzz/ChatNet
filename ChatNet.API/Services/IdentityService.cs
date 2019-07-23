using ChatNet.API.Controllers;
using ChatNet.API.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChatNet.API.Services
{
    public class IdentityService
    {
        private readonly ILogger<IdentityService> _logger;
        private readonly HttpClient _httpClient;

        public IdentityService(ILogger<IdentityService> logger, HttpClient client)
        {
            _logger = logger;
            _httpClient = client;
        }

        public async Task<string> GetTokenForUser(UserLoginWebModel webModel)
        {
            var response = await _httpClient.PostAsJsonAsync("login", webModel);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Couldn't log a user in.");
                throw new Exception("Unable to login a user.");
            }

            return await response.Content.ReadAsStringAsync();
        }

        public async Task Register(UserRegistrationWebModel webModel)
        {
            var response = await _httpClient.PostAsJsonAsync("register", webModel);

            if(!response.IsSuccessStatusCode)
            {
                _logger.LogError("Couldn't register new user.");
                throw new Exception("Unable to register a user.");
            }
        }
    }
}
