using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatNet.Application.SignalR.Hubs
{
    [Authorize]
    public class ChatRoomHub : Hub
    {
        public async Task AddToChatRoom(string chatRoomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatRoomId);
        }
    }
}
