using ChatNet.Application.ValidationRules;
using FluentValidation;

namespace ChatNet.Application.ChatRooms.Queries
{
    public class GetChatRoomQueryValidator : AbstractValidator<GetChatRoomQuery>
    {
        public GetChatRoomQueryValidator()
        {
            RuleFor(c => c.ChatRoomId).MustBeValidGuid();
        }
    }
}
