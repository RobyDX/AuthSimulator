using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Data
{
    /// <summary>
    /// User Table
    /// </summary>
    [Table("User")]
    public class User
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Json Data
        /// </summary>
        [Required]
        public string JsonData { get; set; } = string.Empty;

        /// <summary>
        /// Email
        /// </summary>
        [Required, MaxLength(512)]
        public string Email { get; internal set; } = string.Empty;

        /// <summary>
        /// Password
        /// </summary>
        [Required, MaxLength(512)]
        public string Password { get; internal set; } = string.Empty;

        /// <summary>
        /// Active
        /// </summary>
        public bool Active { get; set; }
    }
}
