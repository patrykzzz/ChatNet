using MediatR;
using System;

namespace ChatNet.Application.Messages.Notifications
{
    public class MessageSentNotification : INotification
    {
        public Guid MessageId { get; set; }
        
    }
}
