using ChatNet.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChatNet.Application.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserTokenModel>
    {
        private readonly IMediator _mediator;
        private readonly IIdentityService _identityService;

        public LoginUserCommandHandler(IMediator mediator, IIdentityService identityService)
        {
            _mediator = mediator;
            _identityService = identityService;
        }

        public async Task<UserTokenModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.LoginUser(request);
            return new UserTokenModel
            {
                Token = result
            };
        }
    }
}
