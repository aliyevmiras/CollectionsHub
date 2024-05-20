using CollectionsHub.Models;
using CollectionsHub.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CollectionsHub.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ApplicationContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signinManager;

        public AccountController(ApplicationContext db, UserManager<User> userManager, SignInManager<User> signinManager)
        {
            _db = db;
            _userManager = userManager;
            _signinManager = signinManager;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginDetails)
        {
            if (!ModelState.IsValid)
            {
                return View(loginDetails);
            }

            var user = await _userManager.FindByEmailAsync(loginDetails.Email);

            if (user == null)
            {
                return View();
            }

            var signinResult = await _signinManager.PasswordSignInAsync(user.UserName, loginDetails.Password, false, false);
            


            if (signinResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(loginDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
    }
}
