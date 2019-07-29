using ChatNet.Application.Interfaces;
using ChatNet.Application.Users.Commands.LoginUser;
using ChatNet.Application.Users.Commands.RegisterUser;
using ChatNet.Application.Users.Models;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ChatNet.Infrastructure
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;

        public IdentityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> LoginUser(LoginUserCommand loginModel)
        {
            var content = PrepareContentFromCommand(loginModel);
            using (var response = await _httpClient.PostAsync("login", content))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Unable to login a user.");
                }

                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<UserDto> RegisterUser(RegisterUserCommand registrationModel)
        {
            var content = PrepareContentFromCommand(registrationModel);
            using (var response = await _httpClient.PostAsync("register", content))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Unable to register a user.");
                }

                return JsonConvert.DeserializeObject<UserDto>(await response.Content.ReadAsStringAsync());
            };
        }


        private HttpContent PrepareContentFromCommand<T>(IRequest<T> command)
        {
            var json = JsonConvert.SerializeObject(command);
            var buffer = Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }
    }
}
