using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Homework5
{
    public static class Login 
    {
        private static Regex regex = new Regex(@"^[A-Za-z]{1}[A-Za-z0-9]{1,9}$"); 
        
        public static bool IsValidViaRegex(string login) 
        {
           return regex.IsMatch(login);
        }

        public static bool IsValidViaChar(string login)
        {
            if (string.IsNullOrWhiteSpace(login?.Trim()) || login.Length > 10 || login.Length < 2 || !char.IsLetter(login[0])) return false;

            foreach (char c in login)
                if (!char.IsLetterOrDigit(c))
                    return false;

            return true;
        }
    }
}
