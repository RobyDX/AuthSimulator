using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Dto.Enums
{
    /// <summary>
    /// Auth Response Types
    /// </summary>
    public enum AuthResponses
    {
        /// <summary>
        /// None
        /// </summary>
        None = 1,
        /// <summary>
        /// Invalid Request
        /// </summary>
        InvalidRequest = 2,
        /// <summary>
        /// Unauthorized Client
        /// </summary>
        UnauthorizedClient = 3,
        /// <summary>
        /// Unsupported Response Type
        /// </summary>
        UnsupportedResponceType = 4,
        /// <summary>
        /// Invalid Scope
        /// </summary>
        InvalidScope = 5
    }
}
