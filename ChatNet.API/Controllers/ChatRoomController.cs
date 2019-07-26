using ChatNet.API.Models;
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
        public async Task<ActionResult<IEnumerable<ChatRoomWebModel>>> GetChatRooms()
        {
            return Ok(await _mediator.Send(new GetAllChatRoomsQuery()));
        }

        //[HttpPost("api/chatrooms")]
        //public async Task Create(ChatRoomWebModel webModel)
        //{
        //    var model = new ChatRoomModel
        //    {
        //        OwnerId = HttpContext.GetUserIdFromRequest(),
        //        Name = webModel.Name
        //    };

        //    await _chatRoomService.Create(model);
        //}
    }
}
