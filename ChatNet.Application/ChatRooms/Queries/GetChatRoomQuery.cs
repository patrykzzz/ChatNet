using ChatNet.Application.ChatRooms.Models;
using MediatR;

namespace ChatNet.Application.ChatRooms.Queries
{
    public class GetChatRoomQuery: IRequest<ChatRoomDto>
    {
        public string ChatRoomId { get; set; }
    }
}
