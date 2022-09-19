using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Module6HW5.Entity;
using Module6HW5.Models;
using System.Security.Claims;
using System.Web;
namespace Module6HW5.Controllers
{
    public class AccountController : Controller
    {
        private readonly EntityContext _context;

        public AccountController(EntityContext context)
        {
            _context = context;
        }


        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUser registerUser)
        {
            var user = new Users();
            user.Name = registerUser.UserName;
            user.Password = registerUser.Password;
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var result = _context.Users.Where(x => x.Name == user.UserName && x.Password == user.Password && x.RoleUsers.Name == user.Role).ToList();

            if (result.Count != 0)
            {
                await Authenticate(user);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = "Incorrect input";
            }
            return View();
        }


        private async Task Authenticate(User user)
        {
            var claim = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };

            ClaimsIdentity id = new ClaimsIdentity(claim, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
