using ChatNet.API.Controllers;
using ChatNet.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChatNet.API.Services
{
    public class IdentityService
    {
        private readonly HttpClient _httpClient;

        public IdentityService(HttpClient client, IConfiguration configuration)
        {
            _httpClient = client;
        }

        public async Task<string> GetTokenForUser(UserLoginWebModel webModel)
        {
            var response = await _httpClient.PostAsJsonAsync("login", webModel);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Unable to login a user.");
            }

            return await response.Content.ReadAsStringAsync();
        }

        public async Task Register(UserRegistrationWebModel webModel)
        {
            var response = await _httpClient.PostAsJsonAsync("register", webModel);

            if(!response.IsSuccessStatusCode)
            {
                throw new Exception("Unable to register a user.");
            }
        }
    }
}
