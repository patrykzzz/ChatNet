using ChatNet.Application.ChatRooms.Models;
using ChatNet.DAL.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChatNet.Application.ChatRooms.Queries
{
    public class GetAllChatRoomsQueryHandler : IRequestHandler<GetAllChatRoomsQuery, List<ChatRoomDto>>
    {
        private readonly IChatNetContext _context;

        public GetAllChatRoomsQueryHandler(IChatNetContext context)
        {
            _context = context;
        }

        public async Task<List<ChatRoomDto>> Handle(GetAllChatRoomsQuery request, CancellationToken cancellationToken)
        {
            return await _context.ChatRooms
                .Select(ChatRoomDto.Projection)
                .ToListAsync();
        }
    }
}
