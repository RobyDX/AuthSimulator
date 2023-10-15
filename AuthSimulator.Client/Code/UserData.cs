using System.Net;

namespace AuthSimulator.Client.Code
{
    /// <summary>
    /// Claims Information
    /// </summary>
    public class UserData
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// Short Name
        /// </summary>
        public string ShortName { get; set; } = string.Empty;
    }
}
