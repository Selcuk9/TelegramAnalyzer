using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramAnalyzer.Models.UserIdentity
{
    public class AppidentityDbContext : IdentityDbContext<AppUser>
    {
        public AppidentityDbContext(DbContextOptions<AppidentityDbContext> options) 
            : base(options)
        {
        }
    }
}
