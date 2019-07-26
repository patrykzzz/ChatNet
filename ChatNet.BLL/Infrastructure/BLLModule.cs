using ChatNet.BLL.Services;
using ChatNet.BLL.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace ChatNet.BLL.Infrastructure
{
    public static class BLLModule
    {
        public static void AddChatNetBLLModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IChatRoomService, ChatRoomService>();
        }
    }
}
