using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.DataAccess.DTOS.Account
{
    public class UserDto
    {
        public string Name { get; set; }
        public string JWT { get; set; }
    }
}
