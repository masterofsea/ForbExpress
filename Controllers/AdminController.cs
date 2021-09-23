using System.Threading.Tasks;
using ForbExpress.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ForbExpress.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<User> UserManager { get; }
        private IUserValidator<User> UserValidator { get; }
        private IPasswordValidator<User> PasswordValidator { get; }
        private IPasswordHasher<User> PasswordHasher { get; }

        public AdminController(UserManager<User> userManager, IUserValidator<User> userValidator, IPasswordValidator<User> passwordValidator,
            IPasswordHasher<User> passwordHasher)
        {
            UserManager = userManager;
            UserValidator = userValidator;
            PasswordValidator = passwordValidator;
            PasswordHasher = passwordHasher;
        }


        public IActionResult Summary() => View(UserManager.Users);


        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(UserCreationModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await UserManager.CreateAsync(user, model.Password);

            if (result.Succeeded) return RedirectToAction("Summary");


            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await UserManager.FindByIdAsync(id);

            if (user != null)
            {
                var result = await UserManager.DeleteAsync(user);
                if (result.Succeeded) return RedirectToAction("Summary");

                AddErrorsFromResult(result);
            }

            else
            {
                ModelState.AddModelError("", "User Not Found");
            }

            return View(nameof(Summary), UserManager.Users);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }


        public async Task<IActionResult> Edit(string id)
        {
            var user = await UserManager.FindByIdAsync(id);

            if (user != null) return View(new UserUpdateModel
            {
                Email = user.Email,
                Id = user.Id
            });

            return RedirectToAction("Summary");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateModel model)
        {
            var user = await UserManager.FindByIdAsync(model.Id);

            if (user != null)
            {
                user.Email = model.Email;
                var validEmail = await UserValidator.ValidateAsync(UserManager, user);

                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }

                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(model.Password))
                {
                    validPass = await PasswordValidator.ValidateAsync(UserManager, user, model.Password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = PasswordHasher.HashPassword(user, model.Password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }

                if ((validEmail.Succeeded && validPass == null) || (validEmail.Succeeded && model.Password != string.Empty && validPass.Succeeded))
                {
                    var result = await UserManager.UpdateAsync(user);

                    if (result.Succeeded) return RedirectToAction("Summary");
                    AddErrorsFromResult(result);
                }
                else
                {
                    ModelState.AddModelError("", "User Not Found");
                }

                return View(new UserUpdateModel
                {
                    Email = user.Email,
                    Id = user.Id
                });

            }

            return View(new UserUpdateModel
            {
                Email = user.Email,
                Id = user.Id
            });
        }
    }
}