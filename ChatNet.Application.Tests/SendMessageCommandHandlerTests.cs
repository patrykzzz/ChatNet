using ChatNet.Application.Interfaces;
using ChatNet.Application.Messages.Commands;
using ChatNet.Application.Messages.Notifications;
using ChatNet.DAL.Abstract;
using ChatNet.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ChatNet.Application.Tests
{
    public class SendMessageCommandHandlerTests
    {
        private SendMessageCommandHandler _target;
        private Mock<IChatNetContext> _context;
        private Mock<IMediator> _mediator;
        private Mock<IClaimsService> _claimsService;

        public SendMessageCommandHandlerTests()
        {
            _context = new Mock<IChatNetContext>();
            _mediator = new Mock<IMediator>();
            _claimsService = new Mock<IClaimsService>();
            _target = new SendMessageCommandHandler(_context.Object, _claimsService.Object, _mediator.Object);

            _context.Setup(x => x.Messages)
                .Returns(new Mock<DbSet<Message>>().Object);
        }

        [Fact]
        public async Task Handle_ForEverythingOk_ShouldSaveChanges()
        {
            // Arrange
            var request = new SendMessageCommand
            {
                ChatRoomId = Guid.NewGuid(),
                Content = "Test content"
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
            var request = new SendMessageCommand
            {
                ChatRoomId = Guid.NewGuid(),
                Content = "Test content"
            };

            // Act 
            await _target.Handle(request, It.IsAny<CancellationToken>());

            // Assert
            _mediator.Verify(x => x.Publish(It.IsAny<MessageSentNotification>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
