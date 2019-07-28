using ChatNet.Application.Users.Models;
using ChatNet.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace ChatNet.Application.ChatRooms.Models
{
    public class ChatRoomDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public UserDto Owner { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public static Expression<Func<ChatRoom, ChatRoomDto>> Projection
        {
            get
            {
                return c => new ChatRoomDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    CreatedOnUtc = c.CreatedOnUtc,
                    Owner = new UserDto
                    {
                        Id = c.OwnerId,
                        FirstName = c.Owner.FirstName,
                        LastName = c.Owner.LastName,
                        Username = c.Owner.Username,
                        Email = c.Owner.Email
                    }
                };
            }
        }
        public static ChatRoomDto Create(ChatRoom chatRoom)
        {
            return Projection.Compile().Invoke(chatRoom);
        }
    }
}
