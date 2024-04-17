using EmailSender.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EmailSender.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Sender> Senders { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
