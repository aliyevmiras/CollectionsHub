using AutoMapper;
using CollectionsHub.Models;
using CollectionsHub.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CollectionsHub.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ApplicationContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signinManager;
        private readonly IMapper _mapper;

        public AccountController(ApplicationContext db, UserManager<User> userManager, SignInManager<User> signinManager, IMapper autoMapper)
        {
            _db = db;
            _userManager = userManager;
            _signinManager = signinManager;
            _mapper = autoMapper;
        }

        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginDetails, string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (!ModelState.IsValid)
            {
                return View(loginDetails);
            }

            var user = await _userManager.FindByEmailAsync(loginDetails.Email);


            if (user == null)
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View(loginDetails);
            }

            var signinResult = await _signinManager.PasswordSignInAsync(user.UserName, loginDetails.Password, false, false);
            
            if (!signinResult.Succeeded)
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View(loginDetails);
            }

            //return RedirectToAction("Index", "Home");


            return RedirectToLocal(returnUrl);
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

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerDetails)
        {
            if(!ModelState.IsValid)
            {
                return View(registerDetails);
            }

            User newUser = _mapper.Map<User>(registerDetails);
            var signupResult = await _userManager.CreateAsync(newUser, registerDetails.Password);

            if (!signupResult.Succeeded)
            {
                foreach (var error in signupResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View(registerDetails);
            }

            await _signinManager.SignInAsync(newUser, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            } 
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
