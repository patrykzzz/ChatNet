using ChatNet.Application.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatNet.Application.Messages.Models
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public UserDto Sender { get; set; }
        public DateTime SentOnUtc { get; set; }
    }
}
