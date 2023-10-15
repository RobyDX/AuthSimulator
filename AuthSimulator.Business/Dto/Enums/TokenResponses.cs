using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Dto.Enums
{
    /// <summary>
    /// Token Response TYpe
    /// </summary>
    public enum TokenResponses
    {
        /// <summary>
        /// None
        /// </summary>
        None = 1,
        /// <summary>
        /// invalid_request
        /// </summary>
        InvalidRequest = 2,
        /// <summary>
        /// invalid_client
        /// </summary>
        InvalidClient = 3,
        /// <summary>
        /// invalid_grant
        /// </summary>
        InvalidGrant = 4,
        /// <summary>
        /// unauthorized_client
        /// </summary>
        UnauthorizedClient = 5,
        /// <summary>
        /// unsupported_grant_type
        /// </summary>
        UnsupportedGrantType = 6,
        /// <summary>
        /// invalid_scope
        /// </summary>
        InvalidScope = 7,
    }
}
