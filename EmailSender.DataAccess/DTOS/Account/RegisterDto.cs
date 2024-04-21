using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.DataAccess.DTOS.Account
{
    public class RegisterDto
    {
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "First name minimiun length {2}, adn maximun {1} characters")]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Password name minimiun length {2}, adn maximun {1} characters")]
        public string Password { get; set; }

        public string? Role { get; set; }
    }
}
