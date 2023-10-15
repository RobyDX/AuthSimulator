using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Dto.Auth
{
    /// <summary>
    /// Error message
    /// </summary>
    public class ErrorMessage
    {
        /// <summary>
        /// Error
        /// </summary>
        [JsonPropertyName("error")]
        public string Error { get; set; } = string.Empty;

        /// <summary>
        /// Error description
        /// </summary>
        [JsonPropertyName("error_description")]
        public string ErrorDescription { get; set; }= string.Empty;
    }
}
