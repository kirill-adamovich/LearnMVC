using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LearnProject.Attribute.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValidEmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            if (!(value is string))
            {
                return true;
            }

            var source = value as string;

            var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.Compiled);
            var match = regex.Match(source);
            return (match.Success && match.Length == source.Length);
        }
    }
}