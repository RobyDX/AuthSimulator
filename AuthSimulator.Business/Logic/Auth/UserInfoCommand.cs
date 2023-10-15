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
    /// Get User Info Request
    /// </summary>
    public class UserInfoRequest : IRequest<string>
    {
        /// <summary>
        /// Authorization Code
        /// </summary>
        public string Authorization { get; set; } = string.Empty;
    }

    /// <summary>
    /// Get User Info Handler
    /// </summary>
    public class UserInfoHandler : IRequestHandler<UserInfoRequest, string>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Request Handler
        /// </summary>
        /// <param name="uof">Unit of Work</param>
        public UserInfoHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Response</returns>
        public async Task<string> Handle(UserInfoRequest request, CancellationToken cancellationToken)
        {
            return await _uof.AuthManager.GetUserInfo(request.Authorization);
        }
    }
}
