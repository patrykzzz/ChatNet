using ChatNet.Application.ChatRooms.Models;
using ChatNet.DAL.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChatNet.Application.ChatRooms.Queries
{
    public class GetChatRoomQueryHandler : IRequestHandler<GetChatRoomQuery, ChatRoomDto>
    {
        private readonly IChatNetContext _context;

        public GetChatRoomQueryHandler(IChatNetContext context)
        {
            _context = context;
        }

        public async Task<ChatRoomDto> Handle(GetChatRoomQuery request, CancellationToken cancellationToken)
        {
            var chatRoomId = Guid.Parse(request.ChatRoomId);
            var entity = await _context.ChatRooms
                .Include(c => c.Messages)
                .Include(c => c.Owner)
                .SingleOrDefaultAsync(c => c.Id == chatRoomId);

            return ChatRoomDto.Create(entity);
        }
    }
}
