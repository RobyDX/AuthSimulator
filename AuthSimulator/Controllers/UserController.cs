using AuthSimulator.Business.Dto.User;
using AuthSimulator.Business.Logic.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace AuthSimulator.Controllers
{
    /// <summary>
    /// User controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator">Mediator</param>
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get List
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserInfoOutput>))]
        public async Task<IActionResult> GetUserList()
        {
            var result = await _mediator.Send(new UserListRequest());
            return Ok(result);
        }

        /// <summary>
        /// Get User Detail
        /// </summary>
        /// <returns>User Detail</returns>
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserInfoOutput>))]
        public async Task<IActionResult> GetUserDetail([FromRoute] int userId)
        {
            var result = await _mediator.Send(new UserDetailRequest() { Id = userId });
            return Ok(result);
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserInfoOutput>))]
        public async Task<IActionResult> SearchUsers([FromQuery] string? text)
        {
            var result = await _mediator.Send(new UserSearchRequest { Text = text ?? "" });
            return Ok(result);
        }

        /// <summary>
        /// Change activation state
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>New activation state</returns>
        [HttpPut("activation/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> ChangeActivation([FromRoute] int id)
        {
            var result = await _mediator.Send(new ChangeActivationUserRequest { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// Delete an user
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>Result</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteUserRequest { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="input">User info input</param>
        /// <returns>User Id</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> Create([FromBody] UserInfoInput input)
        {
            var result = await _mediator.Send(new CreateUserRequest
            {
                Email = input.Email,
                JsonData = input.JsonData,
                Password = input.Password
            });

            return Ok(result);
        }

        /// <summary>
        /// Edit an user
        /// </summary>
        /// <param name="id">User Id</param>
        /// <param name="input"></param>
        /// <returns>User Id</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] UserInfoInput input)
        {
            var result = await _mediator.Send(new EditUserRequest
            {
                Id = id,
                Email = input.Email,
                JsonData = input.JsonData,
                Password = input.Password
            });

            return Ok(result);
        }
    }
}
