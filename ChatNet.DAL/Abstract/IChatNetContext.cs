using ChatNet.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ChatNet.DAL.Abstract
{
    public interface IChatNetContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<ChatRoom> ChatRooms { get; set; }
        Task SaveChangesAsync();
    }
}
