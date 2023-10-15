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
    /// Parameter Type
    /// </summary>
    [Table("ParameterType")]
    public class ParameterType
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
