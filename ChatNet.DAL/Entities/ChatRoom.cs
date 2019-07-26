using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChatNet.DAL.Entities
{
    public class ChatRoom
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<UserInChatRoom> Participants { get; set; }

        //public Guid OwnerID { get; set; }
    }
}
