using Microsoft.EntityFrameworkCore;

namespace RestWithAPIMySQL.Models.Context
{
    public class MysqlServerContext : DbContext
    {
        public MysqlServerContext() { }
      
        public MysqlServerContext (DbContextOptions<MysqlServerContext> options) : base (options) { 
        }
     
        public DbSet<Person> Persons { get; set; }
    }
}
