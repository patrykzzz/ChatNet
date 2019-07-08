using ChatNet.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatNet.DAL
{
    class ChatNetContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=ChatNet;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(s => s.Sender)
                .WithMany(m => m.Messages)
                .HasForeignKey(s => s.SenderId);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.ChatRoom)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ChatRoomId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Messages)
                .WithOne(m => m.Sender)
                .HasForeignKey(m => m.SenderId);

            modelBuilder.Entity<ChatRoom>()
                .Property(c => c.Name)
                .IsRequired();

            modelBuilder.Entity<UserInChatRoom>()
                .HasKey(k => new { k.ChatRoomId, k.UserId });

            modelBuilder.Entity<UserInChatRoom>()
                .HasOne(u => u.User)
                .WithMany(c => c.UserChatRooms)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<UserInChatRoom>()
                .HasOne(u => u.ChatRoom)
                .WithMany(c => c.Participants)
                .HasForeignKey(u => u.ChatRoomId);
        }
    }
}
