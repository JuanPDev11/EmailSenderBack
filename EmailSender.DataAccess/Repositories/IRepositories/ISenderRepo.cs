using EmailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.DataAccess.Repositories.IRepositories
{
    public interface ISenderRepo : IRepository<Sender>
    {
        Task Update(Sender sender);
    }
}
