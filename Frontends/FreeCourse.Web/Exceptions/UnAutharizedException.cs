using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FreeCourse.Web.Exceptions
{
    public class UnAutharizedException : Exception
    {
        public UnAutharizedException()
        {
        }

        public UnAutharizedException(string message) : base(message)
        {
        }

        public UnAutharizedException(string message, Exception innerException) : base(message, innerException)
        {
        }

      
    }
}
