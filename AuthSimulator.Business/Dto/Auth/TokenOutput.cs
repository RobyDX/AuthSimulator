using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Dto.Auth
{
    /// <summary>
    /// Token Output
    /// </summary>
    public class TokenOutput
    {
        /// <summary>
        /// Access Token
        /// </summary>
        [JsonPropertyName("access_token")]
        public string? AccessToken { get; set; }

        /// <summary>
        /// Token Type
        /// </summary>
        [JsonPropertyName("token_type")]
        public string? TokenType { get; set; }

        /// <summary>
        /// Refresh Token
        /// </summary>

        [JsonPropertyName("refresh_token")]
        public string? RefreshToken { get; set; }

        /// <summary>
        /// Expires Time
        /// </summary>

        [JsonPropertyName("expires_in")]
        public string? ExpiresIn { get; set; }
    }
}
