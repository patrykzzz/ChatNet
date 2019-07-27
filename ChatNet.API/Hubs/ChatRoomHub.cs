using ChatNet.Application.ChatRooms.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatNet.API.Hubs
{
    public class ChatRoomHub : Hub
    {
        public async Task NewChatRoomCreated(ChatRoomDto chatroom)
        {
            await Clients.All.SendAsync("chatroomCreated", chatroom);
        }
    }
}
