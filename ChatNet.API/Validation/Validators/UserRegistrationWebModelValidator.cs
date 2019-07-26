using ChatNet.API.Models;
using ChatNet.API.Validation.Rules;
using FluentValidation;

namespace ChatNet.API.Validation.Validators
{
    public class UserRegistrationWebModelValidator : AbstractValidator<UserRegistrationWebModel>
    {
        public UserRegistrationWebModelValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.FirstName).MinimumLength(2);
            RuleFor(x => x.LastName).MinimumLength(2);
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Password).MustBeValidPassword();
        }
    }
}
