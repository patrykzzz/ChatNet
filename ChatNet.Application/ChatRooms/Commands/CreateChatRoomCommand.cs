using ChatNet.Application.ChatRooms.Models;
using MediatR;
using System;

namespace ChatNet.Application.ChatRooms.Commands
{
    public class CreateChatRoomCommand : IRequest
    {
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
    }
}
