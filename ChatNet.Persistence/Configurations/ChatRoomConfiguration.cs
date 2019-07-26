using ChatNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatNet.Persistence.Configurations
{
    public class ChatRoomConfiguration : IEntityTypeConfiguration<ChatRoom>
    {
        public void Configure(EntityTypeBuilder<ChatRoom> builder)
        {
            builder.Property(c => c.Name)
               .IsRequired();

            builder.HasOne(c => c.Owner)
                .WithMany(u => u.OwnedChatRooms)
                .HasForeignKey(c => c.OwnerId);
        }
    }
}
