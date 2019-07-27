using FluentValidation;

namespace ChatNet.Application.ChatRooms.Commands
{
    public class CreateChatRoomCommandValidator : AbstractValidator<CreateChatRoomCommand>
    {
        public CreateChatRoomCommandValidator()
        {
            RuleFor(c => c.Name).MinimumLength(2);
            RuleFor(c => c.OwnerId).Empty();
        }
    }
}
