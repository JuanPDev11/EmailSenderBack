using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.DataAccess.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        ISenderRepo senderRepo { get; }
        ITasksRepo tasksRepo { get; }
        IApplicationUserRepo appUserRepo { get; }
        Task Save();
    }
}
