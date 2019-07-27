using ChatNet.DAL.Abstract;
using ChatNet.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatNet.Application.Users.Notifications
{
    public class UserRegisteredNotificationHandler : INotificationHandler<UserRegisteredNotification>
    {
        private readonly IChatNetContext _context;

        public UserRegisteredNotificationHandler(IChatNetContext context)
        {
            _context = context;
        }

        public async Task Handle(UserRegisteredNotification notification, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = notification.User.Id,
                Username = notification.User.Username,
                Email = notification.User.Email,
                FirstName = notification.User.FirstName,
                LastName = notification.User.LastName
            };

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
        }
    }
}
