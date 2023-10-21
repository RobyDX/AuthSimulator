using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSimulator.Business.CustomExceptions
{
    /// <summary>
    /// Auth Exception Types
    /// </summary>
    public enum AuthExceptionReasons
    {
        /// <summary>
        /// Invalid Request
        /// </summary>
        InvalidRequest = 1,
        /// <summary>
        /// Invalid Scope
        /// </summary>
        InvalidScope = 2,
        /// <summary>
        /// Invalid Client
        /// </summary>
        InvalidClient = 3,
        /// <summary>
        /// Requires Validation
        /// </summary>
        RequiresValidation = 4,
        /// <summary>
        /// Unauthorized Client
        /// </summary>
        UnauthorizedClient = 5,
        /// <summary>
        /// Access Denied
        /// </summary>
        AccessDenied = 6,
        /// <summary>
        /// Invalid Grant
        /// </summary>
        InvalidGrant = 7,
        /// <summary>
        /// Endpoint Disabled
        /// </summary>
        EndpointDisabled = 8,
        /// <summary>
        /// Method Not Allowed
        /// </summary>
        MethodNotAllowed = 9,
        /// <summary>
        /// TooManyRequests
        /// </summary>
        TooManyRequests = 10,
        /// <summary>
        /// Unsupported Response Type
        /// </summary>
        UnsupportedResponseType = 11,
        /// <summary>
        /// Unsupported Grant Type
        /// </summary>
        UnsupportedGrantType = 12,
        /// <summary>
        /// Temporarily Unavailable
        /// </summary>
        TemporarilyUnavailable = 13
    }
}
