using EmailSender.DataAccess.Data;
using EmailSender.DataAccess.Repositories.IRepositories;
using EmailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.DataAccess.Repositories
{
    public class ApplicationUserRepo : Repository<ApplicationUser>, IApplicationUserRepo
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Update(ApplicationUser user)
        {
            var userDb = _context.ApplicationUsers.FirstOrDefault(x => x.Id == user.Id);

            if(userDb != null) 
            {
                userDb.Name = user.Name;
                userDb.Email = user.Email;
                if(user.Role != null)
                {
                    userDb.Role = user.Role;
                }
            }
        }
    }
}
