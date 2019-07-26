using System;
using System.Collections.Generic;

namespace ChatNet.Domain.Entities
{
    public class ChatRoom
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<UserInChatRoom> Participants { get; set; }

        public virtual User User { get; set; }
        public Guid OwnerId { get; set; }
    }
}
