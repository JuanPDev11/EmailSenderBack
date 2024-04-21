using EmailSender.DataAccess.Data;
using EmailSender.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Utility.DbInitializer
{
    public class DbInitializerRepo : IDbInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public DbInitializerRepo(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleMnager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleMnager;
            _context = context;
        }

        public void Initializer()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }

            if (!_roleManager.RoleExistsAsync(WebSiteRole.Role_Super).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebSiteRole.Role_Super)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRole.Role_User)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRole.Role_Analist)).GetAwaiter().GetResult();


                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    Name = "Supervisor",
                }, "Super123").GetAwaiter().GetResult();

                ApplicationUser user = _context.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@gmail.com");
                _userManager.AddToRoleAsync(user, WebSiteRole.Role_Super).GetAwaiter().GetResult();

            }
            return;
        }
    }
}
