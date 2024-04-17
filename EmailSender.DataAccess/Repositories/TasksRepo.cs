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
    public class TasksRepo : Repository<Tasks>, ITasksRepo
    {
        private readonly ApplicationDbContext _context;

        public TasksRepo(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

        public async Task Update(Tasks task)
        {
            var tasksDb = _context.Tasks.FirstOrDefault(x=> x.Id == task.Id);

            if (tasksDb != null) 
            {
                tasksDb.Name = task.Name;
                tasksDb.Periodicity = task.Periodicity;
                tasksDb.Hour = task.Hour;
                tasksDb.Addressee = task.Addressee;
                tasksDb.SenderId = task.SenderId;
            }
        }
    }
}
