using MediatR;
using System;

namespace ChatNet.Application.Messages.Notifications
{
    public class MessageSentNotification : INotification
    {
        public Guid MessageId { get; set; }
        public string Content { get; set; }
        public Guid SenderId { get; set; }
        public Guid ChatRoomId { get; set; }
        public string SenderUsername { get; set; }
        public DateTime SentOnUtc { get; set; }
    }
}
