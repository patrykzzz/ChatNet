using ChatNet.API.Models;
using ChatNet.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatNet.API.Controllers
{
    [ApiController]
    public class ChatRoomController : ControllerBase
    {
        private readonly IChatRoomService _chatRoomService;

        public ChatRoomController(IChatRoomService chatRoomService)
        {
            _chatRoomService = chatRoomService;
        }


        [HttpGet("api/chatrooms")]
        public async Task<IEnumerable<ChatRoomWebModel>> GetChatRooms()
        {
            var result =  await _chatRoomService.GetAll();
            return result.Select(x => new ChatRoomWebModel
            {
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}
