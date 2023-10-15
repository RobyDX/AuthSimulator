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
    /// Edit User Request
    /// </summary>
    public class EditUserRequest : UserInfoInput, IRequest<int>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Edit User Handler
    /// </summary>
    public class EditUserHandler : IRequestHandler<EditUserRequest, int>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Request Handler
        /// </summary>
        /// <param name="uof">Unit of Work</param>
        public EditUserHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Response</returns>
        public Task<int> Handle(EditUserRequest request, CancellationToken cancellationToken)
        {
            return _uof.UserManager.EditUser(request.Id, request);
        }
    }
}
