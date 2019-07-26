using ChatNet.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace ChatNet.Application.Users.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        public static Expression<Func<User, UserDto>> Projection
        {
            get
            {
                return c => new UserDto
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Username = c.Username
                };
            }
        }
    }
}
