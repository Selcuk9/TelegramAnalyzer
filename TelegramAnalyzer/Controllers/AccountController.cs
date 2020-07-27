using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramAnalyzer.Models.UserIdentity;
using TelegramAnalyzer.Models.UserIdentity.Models;
using TelegramAnalyzer.Services;

namespace TelegramAnalyzer.Controllers
{
    [Authorize]
    public class AccountController: Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signInMgr)
        {
            this.userManager = userMgr;
            this.signInManager = signInMgr;
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
            if (ModelState.IsValid)
            {
                var user = await DbMethods.CheckExistUserAsync(userManager, details.Email);

                if (user != null)
                {
                    var result = await DbMethods.CheckPasswordAsync(signInManager, details.Password);

                    if (result)
                    {
                        return Redirect(returnUrl ?? "/");
                    }

                }
                ModelState.AddModelError(nameof(LoginModel.Email), "Неправильный логин или пароль");
            }
                return View(details);
        }
    }
}
