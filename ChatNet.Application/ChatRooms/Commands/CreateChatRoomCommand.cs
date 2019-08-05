using MediatR;

namespace ChatNet.Application.ChatRooms.Commands
{
    public class CreateChatRoomCommand : IRequest
    {
        public string Name { get; set; }
    }
}
