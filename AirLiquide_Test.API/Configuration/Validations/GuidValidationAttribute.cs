using System;
using System.ComponentModel.DataAnnotations;

namespace AirLiquide_Test.API.Configuration.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class GuidValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return Guid.TryParse((string)value, out _);
        }
    }
}