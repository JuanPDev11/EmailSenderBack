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
    public class SenderRepo : Repository<Sender> , ISenderRepo
    {
        private readonly ApplicationDbContext _context;

        public SenderRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Update(Sender sender)
        {
            var senderDb = _context.Senders.FirstOrDefault(x => x.Id == sender.Id);
            if (senderDb != null)
            {
                senderDb.Email = sender.Email;
                senderDb.Password = sender.Password;
                senderDb.Port = sender.Port;
                senderDb.Server = sender.Server;
            }
        }
    }
}
