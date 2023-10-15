using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Dto.Auth
{
    /// <summary>
    /// Auth Options
    /// </summary>
    public class AuthOutput
    {
        /// <summary>
        /// State
        /// </summary>
        [JsonPropertyName("state")]
        public string? State { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        [JsonPropertyName("code")]
        public string? Code { get; set; }
    }
}
