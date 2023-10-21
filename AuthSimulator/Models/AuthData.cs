using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AuthSimulator.Models
{
    /// <summary>
    /// Authorization Data
    /// </summary>
    public class AuthData
    {
        /// <summary>
        /// Response Type
        /// </summary>
        [FromQuery(Name = "response_type")]
        [Required]
        public string ResponseType { get; set; } = string.Empty;

        /// <summary>
        /// Client Id
        /// </summary>
        [FromQuery(Name = "client_id")]
        [Required]
        public string ClientId { get; set; } = string.Empty;

        /// <summary>
        /// Redirect Uri
        /// </summary>
        [FromQuery(Name = "redirect_uri")]
        [Required]
        public string RedirectUri { get; set; } = string.Empty;

        /// <summary>
        /// Scope
        /// </summary>
        [FromQuery(Name = "scope")]
        public string? Scope { get; set; } = string.Empty;
        
        /// <summary>
        /// State
        /// </summary>
        [FromQuery(Name = "state")]
        public string State { get; set; } = string.Empty;
    }
}
