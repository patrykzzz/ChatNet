using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatNet.API.Hubs
{
    public class ChatRoomHub : Hub
    {
        public async Task NewChatRoomCreated(string chatroomName)
        {
            await Clients.All.SendAsync("chatroomCreated", chatroomName);
        }
    }
}
