using System;

namespace ChatNet.Domain.Entities
{
    public class Message
    {
        public Guid Id { get; set; }

        public Guid SenderId { get; set; }
        public virtual User Sender { get; set; }

        public Guid ChatRoomId { get; set; }
        public virtual ChatRoom ChatRoom { get; set; }

        public string Content { get; set; }
        public DateTime SentOnUtc { get; set; }
    }
}
