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
    public class ParameterOutput
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
        /// Value
        /// </summary>
        public string Value { get; set; } = string.Empty;

        
        /// <summary>
        /// Value Type Name
        /// </summary>
        public string ParameterType { get; set; } = string.Empty;
    }
}
