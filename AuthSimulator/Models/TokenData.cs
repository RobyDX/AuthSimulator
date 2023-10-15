using Microsoft.AspNetCore.Mvc;

namespace AuthSimulator.Models
{
    /// <summary>
    /// Token Data
    /// </summary>
    public class TokenData
    {
        /// <summary>
        /// Grant Type
        /// </summary>
        [FromForm(Name = "grant_type")]
        public string GrantType { get; set; } = string.Empty;

        /// <summary>
        /// Client Id
        /// </summary>
        [FromForm(Name = "client_id")]
        public string ClientId { get; set; } = string.Empty;

        /// <summary>
        /// Client Secret
        /// </summary>
        [FromForm(Name = "client_secret")]
        public string ClientSecret { get; set; } = string.Empty;

        /// <summary>
        /// Redirect Uri
        /// </summary>
        [FromForm(Name = "redirect_uri")]
        public string RedirectUri { get; set; } = string.Empty;

        /// <summary>
        /// Code
        /// </summary>
        [FromForm(Name = "code")]
        public string Code { get; set; } = string.Empty;


    }
}
