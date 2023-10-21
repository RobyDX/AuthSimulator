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
    /// Parameter
    /// </summary>
    [Table("Parameter")]
    public class Parameter
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Parameter Name
        /// </summary>
        [Required, MaxLength(512)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Description
        /// </summary>
        [Required, MaxLength(4096)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Value
        /// </summary>
        [Required]
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// Value Type
        /// </summary>
        public int ParameterTypeId { get; set; }

        /// <summary>
        /// Options
        /// </summary>
        public string Options { get; set; } = string.Empty;

        /// <summary>
        /// Parameter Type
        /// </summary>
        [ForeignKey(nameof(ParameterTypeId))]
        public ParameterType ParameterType { get; set; } = null!;
    }
}
