using ChatNet.Application.ChatRooms.Models;
using MediatR;
using System.Collections.Generic;

namespace ChatNet.Application.ChatRooms.Queries
{
    public class GetAllChatRoomsQuery : IRequest<List<ChatRoomDto>>
    {
    }
}
