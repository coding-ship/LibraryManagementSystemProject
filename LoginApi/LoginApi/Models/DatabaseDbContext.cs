using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginApi.Models
{
    public class DatabaseDbContext : DbContext
    {
        public DatabaseDbContext() { }
        public DatabaseDbContext(DbContextOptions<DatabaseDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-ACF98OJL; Database=MyLibrary; Trusted_Connection=True;");
        }
        public virtual DbSet<Usercredentials> Usercredential { get; set; }
        public virtual DbSet<AdminCredentials> AdminCredential { get; set; }

        public virtual DbSet<Usercheck> Usercheck { get; set; }

       
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<IssueDetails> IssueDetail { get; set; }
    }
}
