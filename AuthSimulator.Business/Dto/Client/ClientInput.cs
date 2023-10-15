using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Dto.Client
{
    /// <summary>
    /// Client Input
    /// </summary>
    public class ClientInput
    {
        /// <summary>
        /// Name
        /// </summary>
        [Required, MaxLength(512)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Client Id
        /// </summary>
        [Required, MaxLength(512)]
        public string ClientId { get; set; } = string.Empty;

        /// <summary>
        /// Client Secret
        /// </summary>
        [Required, MaxLength(512)]
        public string ClientSecret { get; set; } = string.Empty;

    }
}
