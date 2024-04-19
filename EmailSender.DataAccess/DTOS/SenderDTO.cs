using EmailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.DataAccess.DTOS
{
    public class SenderDTO
    {
        public Sender Sender { get; set; }
        public IEnumerable<Sender> Senders { get; set; }
        public Tasks TaskUnit { get; set; }
    }
}
