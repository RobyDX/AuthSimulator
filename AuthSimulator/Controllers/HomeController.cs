using AuthSimulator.Business.Dto.Auth;
using AuthSimulator.Business.Logic.User;
using AuthSimulator.Business.Logic.Auth;
using AuthSimulator.Business.Utility;
using AuthSimulator.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthSimulator.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator">Mediat R</param>
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        [Route("home/index")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Show Credential Mask
        /// </summary>
        /// <param name="redirect_uri"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [Route("home/credential")]
        public async Task<IActionResult> Credential([FromQuery] string redirect_uri, [FromQuery] string state)
        {
            ViewBag.redirect_uri = redirect_uri;
            ViewBag.state = state;
            ViewBag.Users = await _mediator.Send(new UserListRequest());
            return View(new CredentialData()
            {
                RedirectUrl = redirect_uri,
                State = state,
                Users = await _mediator.Send(new UserListRequest())
            });
        }

        /// <summary>
        /// Execute Login
        /// </summary>
        /// <param name="email">User Email</param>
        /// <param name="password">User Password</param>
        /// <param name="redirect_uri">Redirect Url</param>
        /// <param name="state">State</param>
        /// <returns></returns>
        [HttpPost, Route("home/login")]
        public async Task<IActionResult> DoLogin(
            [FromForm] string email,
            [FromForm] string password,
            [FromForm] string redirect_uri,
            [FromForm] string state)
        {
            //Generate access code
            var access_code = await _mediator.Send(new LoginRequest() { Email = email, Password = password });

            //prepare output
            AuthOutput output = new()
            {
                State = state,
                Code = access_code,
            };

            //return to client
            return Redirect(redirect_uri + "?" + output.ToQueryString());
        }

        /// <summary>
        /// Execute Login
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="redirect_uri">Redirect Url</param>
        /// <param name="state">State</param>
        /// <returns></returns>
        [HttpPost, Route("home/loginbyid")]
        public async Task<IActionResult> DoLoginById(
            [FromForm] int userId,
            [FromForm] string redirect_uri,
            [FromForm] string state)
        {
            //Generate access code
            var access_code = await _mediator.Send(new LoginByIdRequest() { UserId = userId });

            //prepare output
            AuthOutput output = new()
            {
                State = state,
                Code = access_code,
            };

            //return to client
            return Redirect(redirect_uri + "?" + output.ToQueryString());
        }
        //LOGIN WITH NEW
    }
}
