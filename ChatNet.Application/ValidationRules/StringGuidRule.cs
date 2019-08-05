using FluentValidation;
using System;

namespace ChatNet.Application.ValidationRules
{
    public static class StringGuidRule
    {
        public static IRuleBuilderOptions<T, string> MustBeValidGuid<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(BeValidGuid);
        }

        private static bool BeValidGuid(string guid)
        {
            return Guid.TryParse(guid, out _);
        }
    }
}
