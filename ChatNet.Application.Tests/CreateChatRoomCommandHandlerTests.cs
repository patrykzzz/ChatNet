using ChatNet.Application.ChatRooms.Commands;
using ChatNet.Application.ChatRooms.Notifications;
using ChatNet.Application.Interfaces;
using ChatNet.DAL.Abstract;
using ChatNet.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ChatNet.Application.Tests
{
    public class CreateChatRoomCommandHandlerTests
    {
        private CreateChatRoomCommandHandler _target;
        private Mock<IChatNetContext> _context;
        private Mock<IClaimsService> _claimsService;
        private Mock<IMediator> _mediator;


        public CreateChatRoomCommandHandlerTests()
        {
            _context = new Mock<IChatNetContext>();
            _claimsService = new Mock<IClaimsService>();
            _mediator = new Mock<IMediator>();
            _target = new CreateChatRoomCommandHandler(_context.Object, _claimsService.Object, _mediator.Object);

            _context.Setup(x => x.ChatRooms)
                .Returns(new Mock<DbSet<ChatRoom>>().Object);
        }

        [Fact]
        public async Task Handle_ForEverythingOk_ShouldSaveChanges()
        {
            // Arrange
            var request = new CreateChatRoomCommand
            {
                Name = "ChatRoom name"
            };

            // Act
            await _target.Handle(request, It.IsAny<CancellationToken>());

            // Assert
            _context.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_ForEverythingOk_ShouldSendNotification()
        {
            // Arrange
            var request = new CreateChatRoomCommand
            {
                Name = "ChatRoom name"
            };

            // Act
            await _target.Handle(request, It.IsAny<CancellationToken>());

            // Assert
            _mediator.Verify(x => x.Publish(It.IsAny<ChatRoomCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
