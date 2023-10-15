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
    /// Edit Client Request
    /// </summary>
    public class EditClientRequest : ClientInput, IRequest<int>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Edit Client Handler
    /// </summary>
    public class EditClientHandler : IRequestHandler<EditClientRequest, int>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Request Handler
        /// </summary>
        /// <param name="uof">Unit of Work</param>
        public EditClientHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Response</returns>
        public Task<int> Handle(EditClientRequest request, CancellationToken cancellationToken)
        {
            return _uof.ClientManager.EditCredential(request.Id, request);
        }
    }
}
