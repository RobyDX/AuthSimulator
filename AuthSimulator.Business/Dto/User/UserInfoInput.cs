using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Dto.User
{
    /// <summary>
    /// User Info Input
    /// </summary>
    public class UserInfoInput
    {
        /// <summary>
        /// Json Data
        /// </summary>
        [Required]
        public string JsonData { get; set; } = string.Empty;

        /// <summary>
        /// Email
        /// </summary>
        [Required, MaxLength(512)]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Password
        /// </summary>
        [Required, MaxLength(512)]
        public string Password { get; set; } = string.Empty;
    }
}
