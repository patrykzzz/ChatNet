using ChatNet.Application.ChatRooms.Models;
using ChatNet.Application.ChatRooms.Notifications;
using ChatNet.Application.Interfaces;
using ChatNet.DAL.Abstract;
using ChatNet.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChatNet.Application.ChatRooms.Commands
{
    public class CreateChatRoomCommandHandler : IRequestHandler<CreateChatRoomCommand, Unit>
    {
        private readonly IChatNetContext _context;
        private readonly IClaimsService _claimsService;
        private readonly IMediator _mediator;

        public CreateChatRoomCommandHandler(IChatNetContext context, IClaimsService claimsService, IMediator mediator)
        {
            _context = context;
            _claimsService = claimsService;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateChatRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = new ChatRoom
            {
                Id = Guid.NewGuid(),
                OwnerId = _claimsService.GetCurrentUserId(),
                Name = request.Name,
                CreatedOnUtc = DateTime.UtcNow
            };

            _context.ChatRooms.Add(entity);

            await _context.SaveChangesAsync();

            await _mediator.Publish(new ChatRoomCreatedNotification
            {
                ChatRoomId = entity.Id
            });

            return Unit.Value;
        }
    }
}
