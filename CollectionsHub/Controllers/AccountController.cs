using CollectionsHub.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollectionsHub.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationContext _db;

        public AccountController(ApplicationContext db)
        {
            _db = db;           
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
