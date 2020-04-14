using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Priyank_P_301112923.Models.ViewModels;
using Priyank_P_301112923.Models.Users;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;

namespace Priyank_P_301112923.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        private ILogger logger;
        private bool signedIn = false;

        public AccountController(UserManager<AppUser> userMgr,
            SignInManager<AppUser> signInMgr, ILogger<AccountController> log)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            logger = log;
        }

        public bool getSignedIn() { return signedIn; }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                /*
                AppUser checkUser = new AppUser();
                checkUser.UserName = model.Name;
                */

                //var passCheck = await userManager.CheckPasswordAsync(checkUser, model.Password);
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    signedIn = true;
                    logger.LogInformation("User logged in.");
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        public async Task<ViewResult> Logout()
        {
            signedIn = false;
            await signInManager.SignOutAsync();
            return View("Logout");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.Username };

                // Create new User
                var result = await userManager.CreateAsync(user, model.Password);
                await userManager.AddToRoleAsync(user, "User");                             // Assign "User Role" to newly created account

                if (result.Succeeded)
                {
                    signedIn = true;
                    logger.LogInformation("User created a new account with password.");     // Debugger
                    await signInManager.SignInAsync(user, isPersistent: false);
                    logger.LogInformation("User created a new account with password.");     // Debugger

                    // Add default User role to each new register user account
                    await userManager.AddToRoleAsync(user, "User");

                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        #region Helpers
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        #endregion
    }
}