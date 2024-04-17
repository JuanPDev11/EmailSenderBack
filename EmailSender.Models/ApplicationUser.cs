using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EmailSender.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        
        public string? Role { get; set; }


    }
}
