using AuthSimulator.Business.CustomExceptions;
using AuthSimulator.Business.Manager;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Logic.Auth
{
    /// <summary>
    /// Validate Client Request
    /// </summary>
    public class ValidateClientRequest : IRequest<bool>
    {
        /// <summary>
        /// Client Id
        /// </summary>
        public string ClientId { get; set; } = string.Empty;

        /// <summary>
        /// Client Secret
        /// </summary>
        public string ClientSecret { get; set; } = string.Empty;
    }

    /// <summary>
    /// Validate Client Handler
    /// </summary>
    public class ValidateClientHandler : IRequestHandler<ValidateClientRequest, bool>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Request Handler
        /// </summary>
        /// <param name="uof">Unit of Work</param>
        public ValidateClientHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Response</returns>
        public async Task<bool> Handle(ValidateClientRequest request, CancellationToken cancellationToken)
        {
            var res = await _uof.AuthManager.ValidateClient(request.ClientId, request.ClientSecret);

            if (!res)
                throw new AuthException(AuthExceptionReasons.UnauthorizedClient);

            return res;

        }
    }
}
