using EmployeeRegister.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeRegister.Controllers
{
    public class IdentityController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel, string? returnUrl = null)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            LoginViewModel user = new LoginViewModel()
            {
                Email = "ashu@caliber.com",
                Password = "1234",
            };

            if (loginViewModel != null)
            {
                TempData["UserName"] = user.Email;
            }


            if (loginViewModel == null)
            {
                ModelState.AddModelError("IncorrectData", "Provided login data is incorrect. Please try again.");
                return View(loginViewModel);
            }


            if (loginViewModel.Password != user.Password
                || loginViewModel.Email != user.Email
                )
            {
                ModelState.AddModelError("IncorrectData", "Provided login data is incorrect. Please try again.");
                return View(loginViewModel);
            }
           

            try
            {
                // Security context for Identity
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, "1"),
                    new Claim(ClaimTypes.Name, "Ashutosh Biswal"),
                    new Claim(ClaimTypes.Email, loginViewModel.Email),
                };

                ClaimsIdentity identity = new ClaimsIdentity(claims, "Identity.Application");

                // Container for the security context
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                // Encryption and serialization in a cookie for simplicity
                await HttpContext.SignInAsync("Identity.Application", principal);
            }
            catch (Exception )
            {
                ModelState.AddModelError("AuthError", "An error ocurred during authentication");
                return View();
            }
 
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

    }
}
