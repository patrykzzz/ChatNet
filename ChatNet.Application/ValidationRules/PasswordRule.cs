using FluentValidation;

namespace ChatNet.Application.ValidationRules
{
    public static class PasswordRule
    {
        public static IRuleBuilderOptions<T, string> MustBeValidPassword<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .MinimumLength(5)
                .WithMessage("Password doesn't meet the complexity requirements");
        }
    }
}
