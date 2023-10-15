using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Dto.Auth
{
    /// <summary>
    /// Auth Input
    /// </summary>
    public class AuthInput
    {
        /// <summary>
        /// Response Type
        /// </summary>
        [JsonPropertyName("response_type")]
        public string? ResponseType { get; set; }

        /// <summary>
        /// Client ID
        /// </summary>
        [JsonPropertyName("client_id")]
        public string? ClientId { get; set; }

        /// <summary>
        /// Redirect Uri
        /// </summary>
        [JsonPropertyName("redirect_uri")]
        public string? RedirectUri { get; set; }

        /// <summary>
        /// Scope
        /// </summary>
        [JsonPropertyName("scope")]
        public string? Scope { get; set; }

        /// <summary>
        /// State
        /// </summary>
        [JsonPropertyName("state")]
        public string? State { get; set; }


    }
}
