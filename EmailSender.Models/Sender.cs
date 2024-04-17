using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Models
{
    public class Sender 
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string Email { get; set; }
        [Required] 
        public string Password { get; set; }
        [Required]
        public string Server { get; set; }
        [Required]
        public string Port { get; set; }
    }
}
