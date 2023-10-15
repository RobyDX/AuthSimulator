using AuthSimulator.Business.Dto.Client;
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
    /// Create App Request
    /// </summary>
    public class CreateAppRequest : ClientInput, IRequest<int>
    {
    }

    /// <summary>
    /// Create App Handler
    /// </summary>
    public class CreateAppHandler : IRequestHandler<CreateAppRequest, int>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Request Handler
        /// </summary>
        /// <param name="uof">Unit of Work</param>
        public CreateAppHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Response</returns>
        public Task<int> Handle(CreateAppRequest request, CancellationToken cancellationToken)
        {
            return _uof.ClientManager.CreateClient(request);
        }
    }
}
