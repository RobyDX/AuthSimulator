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
    /// Client Detail Request
    /// </summary>
    public class ClientDetailRequest :  IRequest<ClientOutput>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// App Client Detail Handler
    /// </summary>
    public class ClientDetailHandler : IRequestHandler<ClientDetailRequest, ClientOutput>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Request Handler
        /// </summary>
        /// <param name="uof">Unit of Work</param>
        public ClientDetailHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Response</returns>
        public async Task<ClientOutput> Handle(ClientDetailRequest request, CancellationToken cancellationToken)
        {
            return await _uof.ClientManager.GetDetail(request.Id);
        }
    }
}
