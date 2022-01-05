using Microsoft.EntityFrameworkCore;
using RestWithASPNET5.Models;

namespace RestWithASPNET5.Models.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext() { }
      
        public SqlServerContext (DbContextOptions options) : base (options) { 
        }
     
        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(a => a.Author).WithMany(a => a.Books).HasForeignKey(a => a.AuthorId);
        }
    }
}
