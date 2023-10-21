using AuthSimulator.Business.Dto;

namespace AuthSimulator.Models
{
    /// <summary>
    /// Credential Data
    /// </summary>
    public class CredentialData
    {
        /// <summary>
        /// Redirect Url
        /// </summary>
        public string RedirectUrl { get; set; } = string.Empty;

        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; } = string.Empty;

        /// <summary>
        /// Users
        /// </summary>
        public List<EnumData> Users { get; set; } = new List<EnumData>();
    }
}
