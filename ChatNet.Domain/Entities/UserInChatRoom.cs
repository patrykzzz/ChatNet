using System;

namespace ChatNet.Domain.Entities
{
    public class UserInChatRoom
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid ChatRoomId { get; set; }
        public virtual ChatRoom ChatRoom { get; set; }

    }
}
