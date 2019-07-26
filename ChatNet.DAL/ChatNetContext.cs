﻿using System.Threading.Tasks;
using ChatNet.DAL.Abstract;
using ChatNet.DAL.Entities;
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

            modelBuilder.Entity<ChatRoom>()
                .HasOne(c => c.User)
                .WithMany(u => u.OwnedChatRooms)
                .HasForeignKey(c => c.OwnerId);

            modelBuilder.Entity<UserInChatRoom>()
                .HasKey(k => new
                {
                    k.ChatRoomId,
                    k.UserId
                });

            modelBuilder.Entity<UserInChatRoom>()
                .HasOne(u => u.User)
                .WithMany(c => c.UserChatRooms)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<UserInChatRoom>()
                .HasOne(u => u.ChatRoom)
                .WithMany(c => c.Participants)
                .HasForeignKey(u => u.ChatRoomId);
        }

        async Task IChatNetContext.SaveChangesAsync()
        {
            await SaveChangesAsync();
        }
    }
}
