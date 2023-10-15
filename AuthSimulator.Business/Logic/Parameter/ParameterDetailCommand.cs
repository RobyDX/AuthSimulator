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
    /// Get Parameter Detail Request
    /// </summary>
    public class ParameterDetailRequest : IRequest<ParameterDetailOutput>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Get Parameter Detail Handler
    /// </summary>
    public class ParameterDetailHandler : IRequestHandler<ParameterDetailRequest, ParameterDetailOutput>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Request Handler
        /// </summary>
        /// <param name="uof">Unit of Work</param>
        public ParameterDetailHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Response</returns>
        public async Task<ParameterDetailOutput> Handle(ParameterDetailRequest request, CancellationToken cancellationToken)
        {
            return await _uof.ParameterManager.GetDetail(request.Id);
        }
    }
}
