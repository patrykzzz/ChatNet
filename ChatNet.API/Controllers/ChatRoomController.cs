using ChatNet.Application.ChatRooms.Commands;
using ChatNet.Application.ChatRooms.Models;
using ChatNet.Application.ChatRooms.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatNet.API.Controllers
{
    [ApiController]
    public class ChatRoomController : BaseController
    {
        public ChatRoomController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("api/chatrooms")]
        public async Task<ActionResult<IEnumerable<ChatRoomDto>>> GetChatRooms()
        {
            return Ok(await _mediator.Send(new GetAllChatRoomsQuery()));
        }

        [HttpPost("api/chatrooms")]
        public async Task<IActionResult> Create(CreateChatRoomCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
