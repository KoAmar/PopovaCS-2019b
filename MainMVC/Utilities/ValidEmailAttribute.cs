using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MainMVC.Utilities
{
    public class ValidEmailAttribute : ValidationAttribute
    {
        private readonly string _allowed;

        public ValidEmailAttribute(string allowedDomain)
        {
            _allowed = allowedDomain;
        }

        public override bool IsValid(object value)
        {
            var parts = value.ToString().Split('@');

            var rootDomain = parts[^1].ToLower().Split('.');

            return rootDomain[^1] == "by";
        }
    }
}
