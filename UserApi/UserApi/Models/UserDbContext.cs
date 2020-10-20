using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserApi.Models
{
    public class UserDbContext:DbContext
    {
        public UserDbContext() { }
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-ACF98OJL; Database=MyLibrary; Trusted_Connection=True;");
        }
        public virtual DbSet<Usercredentials> Usercredential { get; set; }
        

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<IssueDetails> IssueDetail { get; set; }
    }
}
