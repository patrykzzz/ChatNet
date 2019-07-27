using ChatNet.Application.ValidationRules;
using FluentValidation;

namespace ChatNet.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.FirstName).MinimumLength(2);
            RuleFor(x => x.LastName).MinimumLength(2);
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Password).MustBeValidPassword();
        }
    }
}
