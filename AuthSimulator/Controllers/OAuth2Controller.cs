using AuthSimulator.Business.CustomExceptions;
using AuthSimulator.Business.Dto.Enums;
using AuthSimulator.Business.Logic.Auth;
using AuthSimulator.Business.Logic.Parameter;
using AuthSimulator.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Text.Json;

namespace AuthSimulator.Controllers
{
    /// <summary>
    /// Oauth2 controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class OAuth2Controller : ControllerBase
    {

        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator">Mediator</param>
        public OAuth2Controller(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Health Check
        /// </summary>
        /// <returns></returns>
        [HttpGet("echo")]
        public string Echo() { return "ok"; }

        /// <summary>
        /// Auth Operation
        /// </summary>
        /// <param name="input">Input</param>
        /// <returns>Result</returns>
        [HttpGet("auth")]
        public async Task<IActionResult> Get([FromQuery] AuthData input)
        {
            if (!ModelState.IsValid)
                throw new AuthException(AuthExceptionReasons.InvalidRequest);

            var responses = input.ResponseType.Split(' ');

            if (responses.Any(x => x == "none"))
                throw new AuthException(AuthExceptionReasons.InvalidRequest);

            if (responses.Any(x => x == "token"))
                throw new AuthException(AuthExceptionReasons.UnsupportedResponseType);

            if (responses.Any(x => x == "id_token"))
                throw new AuthException(AuthExceptionReasons.UnsupportedResponseType);

            //check if client exist and is valid
            await _mediator.Send(new ValidateAuthCallRequest() { ClientId = input.ClientId });

            //get ticket timeout
            var expire = await _mediator.Send(new ParameterValueRequest() { Type = ParameterEnum.Expires });

            //redirect to credential login page
            return Redirect(
                $"/Home/Credential?" +
                $"redirect_uri={Uri.EscapeDataString(input.RedirectUri)}" +
                $"&state={Uri.EscapeDataString(input.State)}" +
                $"&expires_in={expire}");
        }

        /// <summary>
        /// Token End Point
        /// </summary>
        /// <param name="input">Input</param>
        /// <returns>Token Output</returns>
        [HttpPost("token")]
        public async Task<IActionResult> Token([FromForm] TokenData input)
        {
            var output = await _mediator.Send(new TokenRequest()
            {
                CliendId = input.ClientId,
                ClientSecret = input.ClientSecret,
                Code = input.Code,
                GrantType = input.GrantType,
                RedirectUri = input.RedirectUri,
            });

            return Ok(output);
        }

        /// <summary>
        /// User info end point
        /// </summary>
        /// <returns>Information</returns>
        [HttpGet("userinfo")]
        public async Task<IActionResult> UserInfo()
        {
            string auth = "";
            if (Request.Headers.TryGetValue("authorization", out StringValues value))
                auth = value.ToString();

            if (!string.IsNullOrEmpty(Request.Query["access_token"].ToString()))
                auth = Request.Query["access_token"].ToString();

            var jsonData = await _mediator.Send(new UserInfoRequest() { Authorization = auth });
            return Ok(JsonSerializer.Deserialize<dynamic>(jsonData));
        }
    }
}