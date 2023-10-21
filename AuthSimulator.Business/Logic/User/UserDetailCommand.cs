using AuthSimulator.Business.Dto;
using AuthSimulator.Business.Dto.User;
using AuthSimulator.Business.Manager;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Logic.User
{
    /// <summary>
    /// User Detail Request
    /// </summary>
    public class UserDetailRequest : IRequest<UserInfoOutput>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// User Detail Handler
    /// </summary>
    public class UserDetailHandler : IRequestHandler<UserDetailRequest, UserInfoOutput>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Request Handler
        /// </summary>
        /// <param name="uof">Unit of Work</param>
        public UserDetailHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Response</returns>
        public async Task<UserInfoOutput> Handle(UserDetailRequest request, CancellationToken cancellationToken)
        {
            return await _uof.UserManager.GetDetail(request.Id);
        }
    }
}
