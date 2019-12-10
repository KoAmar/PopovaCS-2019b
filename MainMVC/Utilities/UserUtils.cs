using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Castle.Core.Internal;

namespace MainMVC.Utilities
{
    public class UserUtils : ValidationAttribute
    {
        private readonly string[] _allowedDomains;

        public UserUtils(string[] allowedDomains)
        {
            _allowedDomains = allowedDomains;
        }

        public override bool IsValid(object value)
        {
            var result = false;

            var emailPattern = @"^\w{1,30}@\w{1,30}\.\w{1,15}$";

            if (Regex.IsMatch(value.ToString(), emailPattern))
            {
                var parts = value.ToString().Split('@');

                var rootDomain = parts[^1].ToLower().Split('.');

                result = _allowedDomains.Find(s => s == rootDomain[^1]) != null;


            }
            return result;
        }

        public static bool StrongPassword(string password)
        {
            var specialCharacters = new HashSet<char>() { '%', '$', '#' };
            var result = 0;

            if (password.Length >= 6 && password.Length <= 32)
            {
                result++;
                if (password.Any(char.IsLower) &&
                    password.Any(char.IsUpper) &&
                    password.Any(char.IsDigit))
                {
                    result++;
                    if (password.Any(specialCharacters.Contains))
                    {
                        result++;
                    }
                }
            }
            return result >= 3;
        }

    }
}
