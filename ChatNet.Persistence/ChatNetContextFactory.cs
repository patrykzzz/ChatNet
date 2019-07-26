using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ChatNet.DAL.Infrastructure
{
    class ChatNetContextFactory : IDesignTimeDbContextFactory<ChatNetContext>
    {
        public ChatNetContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChatNetContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=ChatNet;Integrated Security=True");

            return new ChatNetContext(optionsBuilder.Options);
        }
    }
}
