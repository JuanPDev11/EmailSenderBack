
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Models
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Periodicity { get; set; }

        [Required]
        public TimeSpan Hour { get; set; }

        [Required]
        public string Addressee { get; set; }

        [Required]
        public int SenderId { get; set; }

        [ValidateNever]
        [ForeignKey("SenderId")]
        public Sender Sender { get; set; }

    }
}
