using EmailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.DataAccess.DTOS
{
    public class TasksDTO
    {
        public IEnumerable<Tasks> Tasks { get; set; }
        public Tasks TasksUnit { get; set; }
    }
}
