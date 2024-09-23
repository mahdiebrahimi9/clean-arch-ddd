using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Application.Shared.Exceptions
{
    public class InvalidCommandException : BaseCommandException
    {
        public InvalidCommandException() { }
        public InvalidCommandException(string message) : base(message)
        {

        }
    }
}
