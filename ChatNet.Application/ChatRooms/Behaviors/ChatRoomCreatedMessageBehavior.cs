using ChatNet.Application.ChatRooms.Commands;
using ChatNet.Application.ChatRooms.Models;
using ChatNet.Application.SignalR.Hubs;
using MediatR.Pipeline;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatNet.Application.ChatRooms.Behaviors
{
    public class ChatRoomCreatedMessageBehavior : IRequestPostProcessor<CreateChatRoomCommand, ChatRoomDto>
    {
        private readonly IHubContext<ChatRoomHub> _hubContext;

        public ChatRoomCreatedMessageBehavior(IHubContext<ChatRoomHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Process(CreateChatRoomCommand request, ChatRoomDto response, CancellationToken cancellationToken)
        {
            await _hubContext.Clients.All.SendAsync("ChatRoomCreated", response);
        }
    }
}
