using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestWithASPNET5.Models;

namespace RestWithASPNET5.Models.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext() { }

        public SqlServerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var converter = new ValueConverter<decimal, double>(
            //v => double.Parse(v.ToString()),
            //v => decimal.Parse(v.ToString())
            //);

            //modelBuilder
            //.Entity<Book>()
            //.Property(e => e.Price)
            //.HasConversion(converter);

            //modelBuilder.Entity<Book>()
            //.Property(p => p.Price)
            //.HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Book>()
                .HasOne(a => a.Author).WithMany(a => a.Books).HasForeignKey(a => a.AuthorId);


        }
    }
}
