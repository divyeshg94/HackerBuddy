using System.Diagnostics;
using System.Security.Claims;
using HackerBuddy.Sql.Interface;
using HackerBuddy.Sql.Models;
using HackerBuddy.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HackerBuddy.Web.Controllers
{
    [Authorize]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonService _personService;

        public HomeController(ILogger<HomeController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public async Task<IActionResult> Index()
        {
            string userEmail = null;

            if (User.Identity?.IsAuthenticated ?? false)
            {
                var userClaims = User.Claims;
                var userClaimUserId = ((ClaimsIdentity)User.Identity).HasClaim(c => c.Type == "UserId");
                if (!userClaimUserId) //TODO: This is not working, Adding claims for every call
                {
                    userEmail = userClaims.FirstOrDefault(c => c.Type == "emails")?.Value;

                    if (!string.IsNullOrEmpty(userEmail))
                    {
                        var user = new Person()
                        {
                            CreatedAt = DateTime.UtcNow,
                            EmailId = userEmail,
                            Name = User.Identity?.Name
                        };
                        var addedUser = await _personService.CreateAsync(user);
                    }
                }
            }

            return new JsonResult("");
            //return View();
        }

        public IActionResult Privacy()
        {
            //return View();
            return new JsonResult("");
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return new JsonResult("");
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
