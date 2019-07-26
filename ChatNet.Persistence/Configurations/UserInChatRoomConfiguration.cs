using ChatNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatNet.Persistence.Configurations
{
    class UserInChatRoomConfiguration : IEntityTypeConfiguration<UserInChatRoom>
    {
        public void Configure(EntityTypeBuilder<UserInChatRoom> builder)
        {
            builder.HasKey(k => new
            {
                k.ChatRoomId,
                k.UserId
            });

            builder.HasOne(u => u.User)
                .WithMany(c => c.UserChatRooms)
                .HasForeignKey(u => u.UserId);

            builder.HasOne(u => u.ChatRoom)
                .WithMany(c => c.Participants)
                .HasForeignKey(u => u.ChatRoomId);
        }
    }
}
