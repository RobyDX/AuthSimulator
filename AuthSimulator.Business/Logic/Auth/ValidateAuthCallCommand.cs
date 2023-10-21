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
    /// Validate Auth Call Request
    /// </summary>
    public class ValidateAuthCallRequest : IRequest<bool>
    {
        /// <summary>
        /// Client Id
        /// </summary>
        public string ClientId { get; set; } = string.Empty;

    }

    /// <summary>
    /// Exist Client Handler
    /// </summary>
    public class ValidateAuthCallHandler : IRequestHandler<ValidateAuthCallRequest, bool>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Request Handler
        /// </summary>
        /// <param name="uof">Unit of Work</param>
        public ValidateAuthCallHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Response</returns>
        public async Task<bool> Handle(ValidateAuthCallRequest request, CancellationToken cancellationToken)
        {
            var res = await _uof.AuthManager.ValidateAuthCall(request.ClientId);

            if (!res)
                throw new AuthException(AuthExceptionReasons.UnauthorizedClient);

            return res;
        }
    }
}
