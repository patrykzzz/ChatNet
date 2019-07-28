using MediatR;
using System;

namespace ChatNet.Application.ChatRooms.Notifications
{
    public class ChatRoomCreatedNotification : INotification
    {
        public Guid ChatRoomId{ get; set; }
    }
}
