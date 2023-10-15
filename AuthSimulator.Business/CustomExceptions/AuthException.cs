using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSimulator.Business.CustomExceptions
{
    /// <summary>
    /// Invalid Client
    /// </summary>
    public class AuthException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reason">Reason</param>
        public AuthException(AuthExceptionReasons reason)
        {
            Reason = reason;
        }

        /// <summary>
        /// Reason
        /// </summary>
        public AuthExceptionReasons Reason { get; private set; }
    }
}
