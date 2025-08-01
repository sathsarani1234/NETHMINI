using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeAPI.Controllers
{
    /// <summary>
    /// Test controller to verify access control is working properly
    /// </summary>
    public class SecurityTestController : Controller
    {
        /// <summary>
        /// Public endpoint - accessible to everyone
        /// </summary>
        [AllowAnonymous]
        public IActionResult Public()
        {
            ViewBag.Message = "This page is accessible to everyone (anonymous users)";
            ViewBag.UserStatus = User.Identity?.IsAuthenticated == true ? "Authenticated" : "Anonymous";
            ViewBag.UserName = User.Identity?.Name ?? "Not logged in";
            return View();
        }

        /// <summary>
        /// Protected endpoint - requires authentication
        /// </summary>
        [Authorize]
        public IActionResult Protected()
        {
            ViewBag.Message = "This page requires authentication";
            ViewBag.UserStatus = "Authenticated";
            ViewBag.UserName = User.Identity?.Name ?? "Unknown";
            return View();
        }
    }
}
