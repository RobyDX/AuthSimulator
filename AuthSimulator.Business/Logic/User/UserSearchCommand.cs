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
    /// User Search Request
    /// </summary>
    public class UserSearchRequest : IRequest<List<UserInfoOutput>>
    {
        /// <summary>
        /// Text
        /// </summary>
        public string Text { get; set; } = string.Empty;
    }

    /// <summary>
    /// User Search Handler
    /// </summary>
    public class UserSearchHandler : IRequestHandler<UserSearchRequest, List<UserInfoOutput>>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Request Handler
        /// </summary>
        /// <param name="uof">Unit of Work</param>
        public UserSearchHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Response</returns>
        public async Task<List<UserInfoOutput>> Handle(UserSearchRequest request, CancellationToken cancellationToken)
        {
            return await _uof.UserManager.Search(request.Text);
        }
    }
}
