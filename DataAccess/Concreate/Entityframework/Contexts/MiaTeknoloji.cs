using Core.Entities.Concreate.Logger;
using Core.Entities.ConCreate;
using Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Entityframework.Contexts
{
    public class MiaTeknoloji : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=desktop-vqhg737;Database=MiaTeknoloji;Trusted_Connection=true");
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<OperationClaim> OperationClaim { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaim{ get; set; }
        public DbSet<BookImage> BookImage { get; set; }
        public DbSet<Logs> Logs { get; set; }

    }
}
