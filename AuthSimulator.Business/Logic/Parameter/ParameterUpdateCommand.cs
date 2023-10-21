using AuthSimulator.Business.Dto.Parameter;
using AuthSimulator.Business.Manager;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Logic.Parameter
{
    /// <summary>
    /// Update Parameter Request
    /// </summary>
    public class ParameterUpdateRequest : ParameterInput, IRequest<bool>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Update Parameter Handler
    /// </summary>
    public class ParameterUpdateHandler : IRequestHandler<ParameterUpdateRequest, bool>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Request Handler
        /// </summary>
        /// <param name="uof">Unit of Work</param>
        public ParameterUpdateHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Response</returns>
        public async Task<bool> Handle(ParameterUpdateRequest request, CancellationToken cancellationToken)
        {
            return await _uof.ParameterManager.UpdateParameter(request.Id, request.Value);
        }
    }
}
