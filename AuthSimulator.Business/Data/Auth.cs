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
    /// Authoritation Table
    /// </summary>
    [Table("Auth")]
    public class Auth
    {
        /// <summary>
        /// Key
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Access Token
        /// </summary>
        public string? AccessToken { get; set; } = string.Empty;

        /// <summary>
        /// Refresh Token
        /// </summary>
        public string? RefreshToken { get; set; }= string.Empty;

        /// <summary>
        /// Expires
        /// </summary>
        public DateTime Expires { get; set; }

        /// <summary>
        /// Valid
        /// </summary>
        public bool Valid { get; set; }

        /// <summary>
        /// User Reference
        /// </summary>
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;
    }
}
