using ChatNet.API.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatNet.API.Hubs
{
    public class ChatRoomHub : Hub
    {
        public async Task NewChatRoomCreated(ChatRoomWebModel chatroom)
        {
            await Clients.All.SendAsync("chatroomCreated", chatroom);
        }
    }
}
