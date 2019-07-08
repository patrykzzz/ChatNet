using System;
using System.Collections.Generic;

namespace ChatNet.DAL.Entities
{
    class User
    {
        public Guid Id { get; set; }

        public string Nick { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<UserInChatRoom> UserChatRooms { get; set; }
    }
}
