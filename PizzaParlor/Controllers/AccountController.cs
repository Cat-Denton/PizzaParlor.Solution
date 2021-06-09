using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PizzaParlor.Models;
using System.Threading.Tasks;
using PizzaParlor.ViewModels;

namespace PizzaParlor.Controllers
{
    public class AccountController : Controller
    {
        private readonly PizzaParlorContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, PizzaParlorContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register (RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View();
            }
        }
    }
}