using System;
using System.Collections.Generic;

namespace ChatNet.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public int DayOfBirth { get; set; }
        public int MonthOfBirth { get; set; }
        public int YearOfBirth { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<UserInChatRoom> UserChatRooms { get; set; }
        public virtual ICollection<ChatRoom> OwnedChatRooms { get; set; }
    }
}
