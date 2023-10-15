using AuthSimulator.Business.Dto.Auth;
using AuthSimulator.Business.Dto.Login;
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
    /// Login Request
    /// </summary>
    public class LoginRequest : LoginInput, IRequest<string>
    {

    }

    /// <summary>
    /// Login Handler
    /// </summary>
    public class LoginHandler : IRequestHandler<LoginRequest, string>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Request Handler
        /// </summary>
        /// <param name="uof">Unit of Work</param>
        public LoginHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Response</returns>
        public async Task<string> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            return await _uof.AuthManager.DoAuth(request.Email, request.Password);
        }
    }
}
