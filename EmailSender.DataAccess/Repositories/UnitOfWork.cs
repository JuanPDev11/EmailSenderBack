using EmailSender.DataAccess.Data;
using EmailSender.DataAccess.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ISenderRepo senderRepo { get; private set; }
        public ITasksRepo tasksRepo { get; private set; }
        public IApplicationUserRepo appUserRepo { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            senderRepo = new SenderRepo(context);
            tasksRepo = new TasksRepo(context);
            appUserRepo = new ApplicationUserRepo(context);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
