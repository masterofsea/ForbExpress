using System.Threading.Tasks;
using ForbExpress.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ForbExpress.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<User> UserManager { get; }
        private SignInManager<User> SignInManager { get; }

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }


        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel details, string returnUrl)
        {
            if (!ModelState.IsValid) return View(details);

            var userName = details.Name.Trim();
            var user = await UserManager.FindByNameAsync(userName);
            if (user == null) return View(details);
            
            await SignInManager.SignOutAsync();
            var result = await SignInManager.PasswordSignInAsync(user, details.Password, false, false);
            if (result.Succeeded) return Redirect(returnUrl ?? "/");
            
            ModelState.AddModelError(nameof(userName), "Invalid user or password");


            return View(details);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }
    }
}