using ChatNet.Application.ValidationRules;
using FluentValidation;

namespace ChatNet.Application.Users.Commands.LoginUser
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).MustBeValidPassword();
        }
    }
}
