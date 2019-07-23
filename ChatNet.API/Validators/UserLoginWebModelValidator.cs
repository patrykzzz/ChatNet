using ChatNet.API.Models;
using FluentValidation;

namespace ChatNet.API.Validators
{
    public class UserLoginWebModelValidator: AbstractValidator<UserLoginWebModel>
    {
        public UserLoginWebModelValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
