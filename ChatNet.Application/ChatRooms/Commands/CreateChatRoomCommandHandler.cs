using ChatNet.Application.ChatRooms.Models;
using ChatNet.Application.Interfaces;
using ChatNet.DAL.Abstract;
using ChatNet.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChatNet.Application.ChatRooms.Commands
{
    public class CreateChatRoomCommandHandler : IRequestHandler<CreateChatRoomCommand, ChatRoomDto>
    {
        private readonly IChatNetContext _context;
        private readonly IClaimsService _claimsService;

        public CreateChatRoomCommandHandler(IChatNetContext context, IClaimsService claimsService)
        {
            _context = context;
            _claimsService = claimsService;
        }

        public async Task<ChatRoomDto> Handle(CreateChatRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = new ChatRoom
            {
                Id = Guid.NewGuid(),
                OwnerId = _claimsService.GetCurrentUserId(),
                Name = request.Name
            };

            _context.ChatRooms.Add(entity);

            await _context.SaveChangesAsync();

            return new ChatRoomDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
