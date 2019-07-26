using ChatNet.BLL.Models;
using ChatNet.BLL.Services.Abstract;
using ChatNet.DAL.Abstract;
using ChatNet.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatNet.BLL.Services
{
    class ChatRoomService : IChatRoomService
    {
        private readonly IChatNetContext _context;

        public ChatRoomService(IChatNetContext context)
        {
            _context = context;
        }
                
        public async Task<IEnumerable<ChatRoomModel>> GetAll()
        {
            var entities = await _context.ChatRooms.ToListAsync();
            return entities.Select(x => new ChatRoomModel
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public Task Create(ChatRoomModel model)
        {
            var entity = new ChatRoom
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                OwnerId = model.OwnerId
            };
            _context.ChatRooms.Add(entity);
            return _context.SaveChangesAsync();
        }
    }
}
