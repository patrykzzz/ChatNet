using ChatNet.Application.Interfaces;
using ChatNet.DAL.Abstract;
using ChatNet.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatNet.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
    {
        private readonly IIdentityService _identityService;
        private readonly IChatNetContext _context;

        public RegisterUserCommandHandler(IIdentityService identityService, IChatNetContext context)
        {
            _identityService = identityService;
            _context = context;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userDto = await _identityService.RegisterUser(request);

            var user = new User
            {
                Id = userDto.Id,
                Email = userDto.Email,
                Username = userDto.Username,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName
            };


            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
            
            return Unit.Value;
        }
    }
}
