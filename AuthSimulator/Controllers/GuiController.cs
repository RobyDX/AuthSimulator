using AuthSimulator.Business.Logic.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthSimulator.Controllers
{
    /// <summary>
    /// Gui Controller
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class GuiController : Controller
    {

        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator">Mediat R</param>
        public GuiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// User Interface
        /// </summary>
        /// <returns></returns>
        [Route("gui/home")]
        public async Task<IActionResult> HomeUi()
        {
            await Task.CompletedTask;
            return PartialView();
        }

        /// <summary>
        /// User Interface
        /// </summary>
        /// <param name="text">search text</param>
        /// <returns></returns>
        [Route("gui/user")]
        public async Task<IActionResult> UserUi([FromQuery] string? text)
        {
            var res = await _mediator.Send(new UserSearchRequest() { Text = text ?? "" });
            return PartialView(res);
        }

        /// <summary>
        /// User Interface
        /// </summary>
        /// <returns></returns>
        [Route("gui/parameter")]
        public IActionResult ParameterUi()
        {
            return PartialView();
        }

        /// <summary>
        /// User Interface
        /// </summary>
        /// <returns></returns>
        [Route("gui/client")]
        public IActionResult ClientUi()
        {
            return PartialView();
        }
    }
}
