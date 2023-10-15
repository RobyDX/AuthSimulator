using AuthSimulator.Business.Data;
using AuthSimulator.Business.Dto.Auth;
using AuthSimulator.Business.Manager;
using AuthSimulator.Business.Utility;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Logic.Auth
{
    /// <summary>
    /// Token Request
    /// </summary>
    public class TokenRequest : TokenInput, IRequest<TokenOutput>
    {
    }

    /// <summary>
    /// Token Request Handler
    /// </summary>
    public class TokenHandler : IRequestHandler<TokenRequest, TokenOutput>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Request Handler
        /// </summary>
        /// <param name="uof">Unit of Work</param>
        public TokenHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Response</returns>
        public async Task<TokenOutput> Handle(TokenRequest request, CancellationToken cancellationToken)
        {
            return await _uof.AuthManager.GenerateToken(request);
        }
    }
}
