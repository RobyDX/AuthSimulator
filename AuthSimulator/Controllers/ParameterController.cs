using AuthSimulator.Business.Dto.Parameter;
using AuthSimulator.Business.Logic.Parameter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthSimulator.Controllers
{
    /// <summary>
    /// Parameter controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ParameterController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator">Mediator</param>
        public ParameterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get List
        /// </summary>
        /// <returns>List of parameters</returns>
        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ParameterOutput>))]
        public async Task<IActionResult> GetUserList()
        {
            var result = await _mediator.Send(new ParameterListRequest());
            return Ok(result);
        }

        /// <summary>
        /// Get Detail
        /// </summary>
        /// <returns>Parameter Detail</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ParameterDetailOutput))]
        public async Task<IActionResult> GetDetail([FromRoute] int id)
        {
            var result = await _mediator.Send(new ParameterDetailRequest() { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// Update Parameter
        /// </summary>
        /// <param name="id">Id</param>
        /// /// <param name="input">input</param>
        /// <returns>Update</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ParameterDetailOutput))]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ParameterInput input)
        {
            var result = await _mediator.Send(new ParameterUpdateRequest()
            {
                Id = id,
                Value = input.Value
            });
            return Ok(result);
        }
    }
}
