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
    /// Create User Request
    /// </summary>
    public class CreateUserRequest : UserInfoInput, IRequest<int>
    {
    }

    /// <summary>
    /// Create User Handler
    /// </summary>
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, int>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Request Handler
        /// </summary>
        /// <param name="uof">Unit of Work</param>
        public CreateUserHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Response</returns>
        public Task<int> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            return _uof.UserManager.CreateUser(request);
        }
    }
}
