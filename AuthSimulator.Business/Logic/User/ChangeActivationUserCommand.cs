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
    /// Change Activation User Request
    /// </summary>
    public class ChangeActivationUserRequest :  IRequest<bool>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Change Activation User Handler
    /// </summary>
    public class ChangeActivationUserHandler : IRequestHandler<ChangeActivationUserRequest, bool>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Request Handler
        /// </summary>
        /// <param name="uof">Unit of Work</param>
        public ChangeActivationUserHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Response</returns>
        public async Task<bool> Handle(ChangeActivationUserRequest request, CancellationToken cancellationToken)
        {
            return await _uof.UserManager.ChangeActivation(request.Id);
        }
    }
}
