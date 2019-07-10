using System.Net.Http;
using System.Threading.Tasks;

namespace ChatNet.API.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpClientFactory ClientFactory;

        public IdentityService(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        public Task LoginUser(string userName, string password)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:");

            return Task.CompletedTask;
        }
    }

    public interface IIdentityService
    {
        Task LoginUser(string userName, string password);
    }
}
