using ChatNet.Application.Users.Models;
using MediatR;

namespace ChatNet.Application.Users.Notifications
{
    public class UserRegisteredNotification : INotification
    {
        public UserDto User { get; set; }
    }
}
