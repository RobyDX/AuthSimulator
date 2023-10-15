using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSimulator.Business.CustomExceptions
{
    /// <summary>
    /// Item not Found Exception
    /// </summary>
    public class ItemNotFoundException : Exception
    {
        private readonly ItemNotFoundTypes _type;
        private readonly string _id;

        /// <summary>
        /// Type
        /// </summary>
        public override string Message => _type switch
        {
            ItemNotFoundTypes.User => $"User: {_id}",
            ItemNotFoundTypes.Client => "Client: {_id}",
            ItemNotFoundTypes.Parameter => "Parameter: {_id}",
            _ => "",
        };

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="id">Item id</param>
        public ItemNotFoundException(ItemNotFoundTypes type, int id)
        {
            _type = type;
            _id = id.ToString();
        }
    }
}
