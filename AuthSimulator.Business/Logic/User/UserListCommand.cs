using AuthSimulator.Business.Dto;
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
    /// User List Request
    /// </summary>
    public class UserListRequest : IRequest<List<EnumData>>
    {

    }

    /// <summary>
    /// User List Handler
    /// </summary>
    public class UserListHandler : IRequestHandler<UserListRequest, List<EnumData>>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Request Handler
        /// </summary>
        /// <param name="uof">Unit of Work</param>
        public UserListHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Response</returns>
        public async Task<List<EnumData>> Handle(UserListRequest request, CancellationToken cancellationToken)
        {
            return await _uof.UserManager.UserList();
        }
    }
}
