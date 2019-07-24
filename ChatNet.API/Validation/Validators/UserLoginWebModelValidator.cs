using ChatNet.API.Models;
using ChatNet.API.Validation.Rules;
using FluentValidation;

namespace ChatNet.API.Validation.Validators
{
    public class UserLoginWebModelValidator : AbstractValidator<UserLoginWebModel>
    {
        public UserLoginWebModelValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).MustBeValidPassword();
        }
    }
}
