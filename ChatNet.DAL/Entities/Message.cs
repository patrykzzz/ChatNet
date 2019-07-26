using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;

namespace ChatNet.DAL.Entities
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid SenderId { get; set; }
        public virtual User Sender { get; set; }

        [Required]
        public Guid ChatRoomId { get; set; }
        public virtual ChatRoom ChatRoom { get; set; }

        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime SentOnUtc { get; set; }
    }
}
