using ChatNet.Application.ChatRooms.Models;
using ChatNet.Application.SignalR.Hubs;
using ChatNet.DAL.Abstract;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChatNet.Application.ChatRooms.Notifications
{
    public class ChatRoomCreatedNotificationHandler : INotificationHandler<ChatRoomCreatedNotification>
    {
        private readonly IHubContext<ChatRoomHub> _hubContext;
        private readonly IChatNetContext _context;

        public ChatRoomCreatedNotificationHandler(IHubContext<ChatRoomHub> hubContext, IChatNetContext context)
        {
            _hubContext = hubContext;
            _context = context;
        }

        public async Task Handle(ChatRoomCreatedNotification notification, CancellationToken cancellationToken)
        {
            var entity = _context.ChatRooms
                .Include(c => c.Owner)
                .Single(c => c.Id == notification.ChatRoomId);

            var chatRoom = ChatRoomDto.Create(entity);

            await _hubContext.Clients.All.SendAsync("ChatRoomCreated", chatRoom);
        }
    }
}
