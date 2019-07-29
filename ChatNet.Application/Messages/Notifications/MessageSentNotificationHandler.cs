using ChatNet.Application.Messages.Models;
using ChatNet.Application.SignalR.Hubs;
using ChatNet.Application.Users.Models;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatNet.Application.Messages.Notifications
{
    public class MessageSentNotificationHandler : INotificationHandler<MessageSentNotification>
    {
        private readonly IHubContext<ChatRoomHub> _hubContext;

        public MessageSentNotificationHandler(IHubContext<ChatRoomHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Handle(MessageSentNotification notification, CancellationToken cancellationToken)
        {
            await _hubContext.Clients
                .Group(notification.ChatRoomId.ToString())
                .SendAsync("MessageReceived", new MessageDto
                {
                    Id = notification.MessageId,
                    Content = notification.Content,
                    Sender = new UserDto
                    {
                        Id = notification.SenderId,
                        Username = notification.SenderUsername
                    },
                    SentOnUtc = notification.SentOnUtc
                });
        }
    }
}
