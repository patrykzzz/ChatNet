using MediatR;
using System;

namespace ChatNet.Application.Messages.Commands
{
    public class SendMessageCommand : IRequest
    {
        public string Content { get; set; }
        public Guid ChatRoomId { get; set; }
    }
}
