using MediatR;

namespace ChatNet.Application.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<UserTokenModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
