using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_5_Throwing_Exceptions
{
    public class InvalidUsernameException : System.Exception
    {
        public InvalidUsernameException(string message) : base(message) { }
    }
}
