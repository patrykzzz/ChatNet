using MediatR;

namespace ChatNet.Application.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<UserTokenDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
