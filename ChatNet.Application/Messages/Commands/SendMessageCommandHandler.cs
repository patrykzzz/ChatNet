using ChatNet.Application.Interfaces;
using ChatNet.Application.Messages.Notifications;
using ChatNet.DAL.Abstract;
using ChatNet.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChatNet.Application.Messages.Commands
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, Unit>
    {
        private readonly IChatNetContext _context;
        private readonly IClaimsService _claimsService;
        private readonly IMediator _mediator;

        public SendMessageCommandHandler(IChatNetContext context, IClaimsService claimsService, IMediator mediator)
        {
            _context = context;
            _claimsService = claimsService;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var entity = new Message
            {
                Id = Guid.NewGuid(),
                ChatRoomId = request.ChatRoomId,
                Content = request.Content,
                SenderId = _claimsService.GetCurrentUserId(),
                SentOnUtc = DateTime.UtcNow
            };

            await _context.Messages.AddAsync(entity);
            await _context.SaveChangesAsync();

            await _mediator.Publish(new MessageSentNotification
            {
                MessageId = entity.Id
            });

            return Unit.Value;
        }
    }
}
