using System.Threading.Tasks;
using ChatNet.DAL.Abstract;
using ChatNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatNet.DAL
{
    public class ChatNetContext : DbContext, IChatNetContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }

        public ChatNetContext(DbContextOptions<ChatNetContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChatNetContext).Assembly);
        }

        async Task IChatNetContext.SaveChangesAsync()
        {
            await SaveChangesAsync();
        }
    }
}
