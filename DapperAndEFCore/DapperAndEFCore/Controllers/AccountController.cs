using DapperAndEFCore.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

//change pw by admin
//https://stackoverflow.com/questions/69133617/is-there-any-way-to-change-password-with-out-the-old-password-and-email-verifica
namespace DapperAndEFCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register userRegInfo)
        {
            if (!ModelState.IsValid) { return View(); }

            IdentityUser user = new IdentityUser 
            { 
                Email = userRegInfo.Email,
                UserName = userRegInfo.UserName
            };
            IdentityResult result = await _userManager.CreateAsync(user, userRegInfo.Password);
            if (result.Succeeded) 
            {
                return RedirectToAction("Login");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Register", error.Description);
                }
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Credential userLoginInfo)
        {
            if (!ModelState.IsValid) { return View(); }

            var result = await _signInManager.PasswordSignInAsync(
                    userLoginInfo.UserName,
                    userLoginInfo.Password,
                    userLoginInfo.RememberMe,
                    false
                );
            if (result.Succeeded) 
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("Login", "You are locked out");
                }
                else
                {
                    ModelState.AddModelError("Login", "Failed to login");
                }
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
