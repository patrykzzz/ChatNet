using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatNet.API.Models
{
    public class ChatRoomWebModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
    }
}
