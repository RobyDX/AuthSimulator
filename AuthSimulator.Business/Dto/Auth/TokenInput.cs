using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Dto.Auth
{
    /// <summary>
    /// Token Input
    /// </summary>
    public class TokenInput
    {
        /// <summary>
        /// Client ID
        /// </summary>
        [JsonPropertyName("client_id")]
        public string? CliendId { get; set; }

        /// <summary>
        /// Redirect Uri
        /// </summary>
        [JsonPropertyName("redirect_uri")]
        public string? RedirectUri { get; set; }

        /// <summary>
        /// Client Secret
        /// </summary>
        [JsonPropertyName("client_secret")]
        public string? ClientSecret { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        [JsonPropertyName("code")]
        public string? Code { get; set; }

        /// <summary>
        /// Grant Type
        /// </summary>
        [JsonPropertyName("grant_type")]
        public string? GrantType { get; set; }
    }
}
