using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_5_Throwing_Exceptions
{
    public class UserInputValidator
    {
        public static void ValidateUsername(string username)
        {
            if (username.Length < 5)
            {
                throw new InvalidUsernameException("Username must be at least 5 characters long.");
            }
        }

        public static void ValidatePassword(string password)
        {
            if (password.Length < 8)
            {
                throw new InvalidPasswordException("Password must be at least 8 characters long.");
            }
            if (!password.Any(char.IsDigit))
            {
                throw new InvalidPasswordException("Password must contain at least one number.");
            }
        }
    }
}
