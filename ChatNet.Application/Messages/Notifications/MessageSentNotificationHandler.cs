using ChatNet.Application.Messages.Models;
using ChatNet.Application.SignalR.Hubs;
using ChatNet.Application.Users.Models;
using ChatNet.DAL.Abstract;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ChatNet.Application.Messages.Notifications
{
    public class MessageSentNotificationHandler : INotificationHandler<MessageSentNotification>
    {
        private readonly IHubContext<ChatRoomHub> _hubContext;
        private readonly IChatNetContext _context;

        public MessageSentNotificationHandler(IHubContext<ChatRoomHub> hubContext, IChatNetContext context)
        {
            _hubContext = hubContext;
            _context = context;
        }

        public async Task Handle(MessageSentNotification notification, CancellationToken cancellationToken)
        {
            var message = await _context.Messages
                .Include(m => m.Sender)
                .SingleOrDefaultAsync(m => m.Id == notification.MessageId);

            await _hubContext.Clients
                .Groups(message.ChatRoomId.ToString())
                .SendAsync("MessageReceived", new MessageDto
                {
                    Id = message.Id,
                    Content = message.Content,
                    Sender = new UserDto
                    {
                        Id = message.Sender.Id,
                        Username = message.Sender.Username,
                        Email = message.Sender.Email,
                        FirstName = message.Sender.FirstName,
                        LastName = message.Sender.LastName
                    },
                    SentOnUtc = message.SentOnUtc
                });
        }
    }
}
