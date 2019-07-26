using ChatNet.API.Helpers;
using ChatNet.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatNet.API.Controllers
{
    [ApiController]
    public class ChatRoomController : ControllerBase
    {
        //private readonly IChatRoomService _chatRoomService;

        //public ChatRoomController(IChatRoomService chatRoomService)
        //{
        //    _chatRoomService = chatRoomService;
        //}


        //[HttpGet("api/chatrooms")]
        //public async Task<IEnumerable<ChatRoomWebModel>> GetChatRooms()
        //{
        //    var result =  await _chatRoomService.GetAll();
        //    return result.Select(x => new ChatRoomWebModel
        //    {
        //        Id = x.Id,
        //        Name = x.Name
        //    });
        //}

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
