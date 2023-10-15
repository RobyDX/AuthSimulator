using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Dto.Enums
{
    /// <summary>
    /// Parameter Type
    /// </summary>
    public enum ParameterEnum
    {
        /// <summary>
        /// Client is active
        /// </summary>
        ClientActive = 1,
        /// <summary>
        /// Expire Secons
        /// </summary>
        Expires = 2,
        /// <summary>
        /// Auth Response
        /// </summary>
        AuthResponse = 3,
        /// <summary>
        /// Token Response
        /// </summary>
        TokenResponse = 4
    }
}
