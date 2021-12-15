using Microsoft.EntityFrameworkCore;

namespace RestWithAPSNET.Models.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext() { }
      
        public SqlServerContext (DbContextOptions options) : base (options) { 
        }
     
        public DbSet<Person> Persons { get; set; }
    }
}
