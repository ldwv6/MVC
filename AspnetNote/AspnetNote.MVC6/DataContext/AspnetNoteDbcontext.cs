using AspnetNote.MVC6.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetNote.MVC6.DataContext
{
    public class AspnetNoteDbcontext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<User> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ldwv6\Documents\AspnetNoteDb.mdf;Integrated Security=True;Connect Timeout=30");
        }
    }
}
