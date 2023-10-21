using AuthSimulator.Client.Code;
using AuthSimulator.Client.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AuthSimulator.Client.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    public class HomeController : Controller
    {


        /// <summary>
        /// Constructor
        /// </summary>
        public HomeController()
        {

        }

        /// <summary>
        /// Home Page
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index()
        {
            var logged = User?.Identity?.IsAuthenticated ?? false;
            ViewBag.Logged = logged;

            if (logged && User != null && User.Identity != null)
            {
                ViewBag.Name = User.Identity.Name;

                ViewBag.Claims = User.Identities
                    .First()
                    .Claims
                    .Select(c => new UserData() { Name = c.Type, ShortName = c.Type.Split(@"/").Last(), Value = c.Value }).ToList();
            }

            return View();
        }

        /// <summary>
        /// Logoff
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logoff()
        {
            await HttpContext.SignOutAsync();
            return Redirect(Url.Action("index") ?? "/");
        }

        /// <summary>
        /// Start Oauth workflow
        /// </summary>
        /// <param name="provider">Provider</param>
        /// <returns>Redirect</returns>
        [HttpPost]
        public IActionResult DoOauth([FromForm] string provider)
        {
            var url = Url.Action(action: "index", controller: "Home", values: null, protocol: Request.Scheme);

            string schema = GoogleDefaults.AuthenticationScheme;

            switch (provider)
            {
                case "google":
                    schema = GoogleDefaults.AuthenticationScheme;
                    break;
                case "custom":
                    schema = "custom";
                    break;
                case "facebook":
                    schema = FacebookDefaults.AuthenticationScheme;
                    break;
                case "microsoft":
                    schema = MicrosoftAccountDefaults.AuthenticationScheme;
                    break;
                default:
                    break;
            }

            return Challenge(new AuthenticationProperties() { RedirectUri = url }, schema);
        }

        /// <summary>
        /// Test Auth method
        /// </summary>
        /// <returns>Test</returns>
        [Authorize]
        [HttpGet("testauth")]
        public IActionResult TestAuth()
        {
            return Ok("ok");
        }

        /// <summary>
        /// Error View
        /// </summary>
        /// <returns>View</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}