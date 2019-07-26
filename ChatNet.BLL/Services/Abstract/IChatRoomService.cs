using ChatNet.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatNet.BLL.Services.Abstract
{
    public interface IChatRoomService
    {
        Task<IEnumerable<ChatRoomModel>> GetAll();
    }
}
