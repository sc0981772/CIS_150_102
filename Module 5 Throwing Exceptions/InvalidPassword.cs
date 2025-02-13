using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_5_Throwing_Exceptions
{
    public class InvalidPasswordException : System.Exception
    {
        public InvalidPasswordException(string message) : base(message) { }
    }
}
