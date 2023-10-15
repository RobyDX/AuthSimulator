using AuthSimulator.Business.Dto.Client;
using AuthSimulator.Business.Dto.User;
using AuthSimulator.Business.Logic.Client;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthSimulator.Controllers
{

    /// <summary>
    /// App Credential controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator">Mediator</param>
        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Get List
        /// </summary>
        /// <returns>List of client</returns>
        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ClientOutput>))]
        public async Task<IActionResult> GetUserList()
        {
            var result = await _mediator.Send(new ClientListRequest());
            return Ok(result);
        }

        /// <summary>
        /// Get Detail
        /// </summary>
        /// <returns>List of client</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientOutput))]
        public async Task<IActionResult> GetDetail([FromRoute] int id)
        {
            var result = await _mediator.Send(new ClientDetailRequest() { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// Change activation state
        /// </summary>
        /// <param name="id">client Id</param>
        /// <returns>New activation state</returns>
        [HttpPut("activation/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> ChangeActivation([FromRoute] int id)
        {
            var result = await _mediator.Send(new ChangeActivationClientRequest { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// Delete a client
        /// </summary>
        /// <param name="id">Client Id</param>
        /// <returns>Result</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteAppRequest { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// Create new Client
        /// </summary>
        /// <param name="input">Client input</param>
        /// <returns>Client Id</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> Create([FromBody] ClientInput input)
        {
            var result = await _mediator.Send(new CreateAppRequest
            {
                ClientId = input.ClientId,
                ClientSecret = input.ClientSecret,
                Name = input.Name
            });

            return Ok(result);
        }

        /// <summary>
        /// Edit a Client
        /// </summary>
        /// <param name="id">Client Id</param>
        /// <param name="input"></param>
        /// <returns>Client Id</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] ClientInput input)
        {
            var result = await _mediator.Send(new EditClientRequest
            {
                Name = input.Name,
                ClientSecret = input.ClientSecret,
                ClientId = input.ClientId,
                Id = id
            });

            return Ok(result);
        }
    }
}
