using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Dto.Login
{
    /// <summary>
    /// Login Input
    /// </summary>
    public class LoginInput
    {
        /// <summary>
        /// Email Address
        /// </summary>
        [Required, MaxLength(512), DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Password
        /// </summary>
        [Required, MaxLength(512), DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
