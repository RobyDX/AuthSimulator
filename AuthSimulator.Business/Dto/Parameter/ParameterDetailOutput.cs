using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Dto.Parameter
{
    /// <summary>
    /// Parameter Output
    /// </summary>
    public class ParameterDetailOutput
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Parameter Name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Value Type Id
        /// </summary>
        public int ParameterTypeId { get; set; }

        /// <summary>
        /// Options
        /// </summary>
        public string Options { get; set; } = string.Empty;

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; } = string.Empty;
    }
}