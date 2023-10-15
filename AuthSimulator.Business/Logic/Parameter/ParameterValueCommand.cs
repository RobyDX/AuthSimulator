using AuthSimulator.Business.Dto.Enums;
using AuthSimulator.Business.Manager;
using MediatR;

namespace AuthSimulator.Business.Logic.Parameter
{
    /// <summary>
    /// Get Parameter Value Request
    /// </summary>
    public class ParameterValueRequest : IRequest<string>
    {
        /// <summary>
        /// Parameter Type
        /// </summary>
        public ParameterEnum Type { get; set; }
    }

    /// <summary>
    /// Get Parameter Value Handler
    /// </summary>
    public class ParameterValueHandler : IRequestHandler<ParameterValueRequest, string>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Request Handler
        /// </summary>
        /// <param name="uof">Unit of Work</param>
        public ParameterValueHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Response</returns>
        public async Task<string> Handle(ParameterValueRequest request, CancellationToken cancellationToken)
        {
            return await _uof.ParameterManager.GetParameterValue(request.Type);
        }
    }
}
