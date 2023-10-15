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
    /// Client
    /// </summary>
    [Table("Client")]
    public class Client
    {
        /// <summary>
        /// Key
        /// </summary>
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required,MaxLength(512)]
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

        /// <summary>
        /// App Active
        /// </summary>
        public bool Active { get; set; }
    }
}
