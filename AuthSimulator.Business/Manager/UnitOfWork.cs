using AuthSimulator.Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Manager
{
    /// <summary>
    /// Unit of Work
    /// </summary>
    public class UnitOfWork
    {
        private readonly DB _context;

        /// <summary>
        /// Authorization Manager
        /// </summary>
        public AuthManager AuthManager { get { return new AuthManager(_context); } }

        /// <summary>
        /// User Manager
        /// </summary>
        public UserManager UserManager { get { return new UserManager(_context); } }


        /// <summary>
        ///  Client Manager
        /// </summary>
        public ClientManager ClientManager { get { return new ClientManager(_context); } }

        /// <summary>
        /// Parameter Manager
        /// </summary>
        public ParameterManager ParameterManager { get { return new ParameterManager(_context); } }

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(DB context)
        {
            _context = context;
        }
    }
}
