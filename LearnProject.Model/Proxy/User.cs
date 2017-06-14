using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LearnProject.Model
{
    public partial class User : IValidatableObject
    {
        public static string GetActivateUrl()
        {
            return Guid.NewGuid().ToString("N");
        }

        public string ConfirmPassword { get; set; }

        public string Captcha { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //Не нулевой Email
            if (string.IsNullOrWhiteSpace(Email))
            {
                yield return new ValidationResult("R. Введите email", new string[] { "Email" });
            }
            else
            {
                //корректный Email
                var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.Compiled);
                var match = regex.Match(Email);
                if (!(match.Success && match.Length == Email.Length))
                {
                    yield return new ValidationResult("R. Введите корректный email", new string[] { "Email" });
                }
            }
            
            //пароль не нулевой
            if (string.IsNullOrWhiteSpace(Password))
            {
                yield return new ValidationResult("R. Введите пароль", new string[] { "Password" }); 
            }

            //пароли совпадают
            if (Password != ConfirmPassword)
            {
                yield return new ValidationResult("R. Пароли не совпадают", new string[] { "ConfirmPassword" });
            }
        }

        public bool InRoles(string roles)
        {
            if (string.IsNullOrWhiteSpace(roles))
            {
                return false;
            }

            var rolesArray = roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var role in rolesArray)
            {
                var hasRole = UserRoles.Any(p => string.Compare(p.Role.Code, role, true) == 0);
                if (hasRole)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
