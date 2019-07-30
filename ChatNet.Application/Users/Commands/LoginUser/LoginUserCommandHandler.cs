using ChatNet.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChatNet.Application.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserTokenDto>
    {
        private readonly IIdentityService _identityService;

        public LoginUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<UserTokenDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.LoginUser(request);
        }
    }
}
