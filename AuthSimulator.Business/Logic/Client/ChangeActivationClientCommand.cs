using AuthSimulator.Business.Dto.User;
using AuthSimulator.Business.Manager;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Logic.Client
{
    /// <summary>
    /// Change Activation Client Request
    /// </summary>
    public class ChangeActivationClientRequest :  IRequest<bool>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Change Activation Client Handler
    /// </summary>
    public class ChangeActivationClientHandler : IRequestHandler<ChangeActivationClientRequest, bool>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Request Handler
        /// </summary>
        /// <param name="uof">Unit of Work</param>
        public ChangeActivationClientHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Response</returns>
        public async Task<bool> Handle(ChangeActivationClientRequest request, CancellationToken cancellationToken)
        {
            return await _uof.ClientManager.ChangeActivationCredential(request.Id);
        }
    }
}
