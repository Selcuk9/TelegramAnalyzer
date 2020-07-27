using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramAnalyzer.Models.UserIdentity;

namespace TelegramAnalyzer.Services
{
    public static class DbMethods
    {
        private static AppUser user;
        public async static Task<AppUser> CheckExistUserAsync(UserManager<AppUser> userManager, string email)
        {
            if (userManager == null && email == null)
            {
                return null;
            }

            user = await userManager.FindByEmailAsync(email);

            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async static Task<bool> CheckPasswordAsync(SignInManager<AppUser> signIn, string password)
        {
            await signIn.SignOutAsync();
            var result = await signIn.PasswordSignInAsync(user, password, false, false);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
