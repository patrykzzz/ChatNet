using ChatNet.Application.Users.Models;
using ChatNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ChatNet.Application.ChatRooms.Models
{
    public class ChatRoomDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public UserDto Owner { get; set; }

        public static Expression<Func<ChatRoom, ChatRoomDto>> Projection
        {
            get
            {
                return c => new ChatRoomDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Owner = new UserDto
                    {
                        Id = c.OwnerId,
                        FirstName = c.Owner.FirstName,
                        LastName = c.Owner.LastName,
                        Username = c.Owner.Username                        
                    }
                };
            }
        }
    }
}
