using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Dto.User
{
    /// <summary>
    /// User Info Output
    /// </summary>
    public class UserInfoOutput
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Json Data
        /// </summary>
        public string JsonData { get; set; } = string.Empty;

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Active
        /// </summary>
        public bool Active { get; set; }
    }
}
