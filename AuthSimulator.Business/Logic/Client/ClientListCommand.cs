using AuthSimulator.Business.Dto;
using AuthSimulator.Business.Dto.Client;
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
    /// Client List Request
    /// </summary>
    public class ClientListRequest : IRequest<List<ClientOutput>>
    {

    }

    /// <summary>
    /// Client List Handler
    /// </summary>
    public class ClientListHandler : IRequestHandler<ClientListRequest, List<ClientOutput>>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Request Handler
        /// </summary>
        /// <param name="uof">Unit of Work</param>
        public ClientListHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Response</returns>
        public async Task<List<ClientOutput>> Handle(ClientListRequest request, CancellationToken cancellationToken)
        {
            return await _uof.ClientManager.GetList();
        }
    }
}
