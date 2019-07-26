using ChatNet.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatNet.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
    {
        private readonly IMediator _mediator;
        private readonly IIdentityService _identityService;

        public RegisterUserCommandHandler(IMediator mediator, IIdentityService identityService)
        {
            _mediator = mediator;
            _identityService = identityService;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            await _identityService.RegisterUser(request);
            return Unit.Value;
        }
    }
}
