using ChatNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatNet.Persistence.Configurations
{
    class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.SentOnUtc)
                .IsRequired();

            builder.Property(m => m.Content)
                .IsRequired();

            builder.HasOne(s => s.Sender)
                .WithMany(m => m.Messages)
                .HasForeignKey(s => s.SenderId);

            builder.HasOne(m => m.ChatRoom)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ChatRoomId);
        }
    }
}
