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
    /// Get Parameter List Request
    /// </summary>
    public class ParameterListRequest : IRequest<List<ParameterOutput>>
    {
    }

    /// <summary>
    /// Get Parameter List Handler
    /// </summary>
    public class ParameterListHandler : IRequestHandler<ParameterListRequest, List<ParameterOutput>>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Request Handler
        /// </summary>
        /// <param name="uof">Unit of Work</param>
        public ParameterListHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Response</returns>
        public async Task<List<ParameterOutput>> Handle(ParameterListRequest request, CancellationToken cancellationToken)
        {
            return await _uof.ParameterManager.GetList();
        }
    }
}
