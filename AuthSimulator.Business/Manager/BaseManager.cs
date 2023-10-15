using AuthSimulator.Business.CustomExceptions;
using AuthSimulator.Business.Data;
using AuthSimulator.Business.Dto.Enums;
using Microsoft.EntityFrameworkCore;

namespace AuthSimulator.Business.Manager
{
    /// <summary>
    /// Base Storage Manager
    /// </summary>
    public abstract class BaseManager
    {
        /// <summary>
        /// Database Context
        /// </summary>
        public DB Context { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Database Context</param>
        public BaseManager(DB context)
        {
            Context = context;
        }

        /// <summary>
        /// Get Parameter value
        /// </summary>
        /// <param name="parameter">Parameter</param>
        /// <returns>Parameter Value</returns>
        public async Task<string> GetParameterValue(ParameterEnum parameter)
        {
            return await Context
                .Parameters
                .Where(p => p.Id == (int)parameter)
                .Select(p => p.Value)
                .FirstOrDefaultAsync() ?? throw new ItemNotFoundException(ItemNotFoundTypes.Parameter, (int)parameter);
        }
    }
}
