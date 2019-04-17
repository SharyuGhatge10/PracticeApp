using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tourisum.Validation
{
    public class Validations
    {
        private static readonly string EMAIL_REGEX_TEMPLATE = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
        private static readonly string FULLNAME_LETTERS = @"([a-zA-Z\-]+)\s+([a-zA-Z\-]+$)";
        private static readonly string PHONE_DEGITS = "0123456789";

        private static Regex __emailRegex;
        private static Regex _fullnameVald;


        public Validations()
        {
            __emailRegex = new Regex(EMAIL_REGEX_TEMPLATE, RegexOptions.IgnoreCase);
            _fullnameVald = new Regex(FULLNAME_LETTERS, RegexOptions.IgnoreCase);
        }

        public static bool EmailIsValid(string email)
        {
            return ((!String.IsNullOrEmpty(email)) && (__emailRegex.IsMatch(email)));
        }

        public static bool FullNameIsValid(string name)
        {
            return _fullnameVald.IsMatch(name);
        }

        public static string PreparePhoneNumber(string phoneNumber)
        {
            var result = "";
            var index = 0;
            while (index < phoneNumber.Length)
            {
                if (PHONE_DEGITS.IndexOf(phoneNumber[index]) >= 0)
                    result += phoneNumber.Substring(index, 1);
                index++;
            }

            if (result.Length > 10)
            {
                result = result.Substring(result.Length - 10);
            }
            return result;
        }
    }
}
