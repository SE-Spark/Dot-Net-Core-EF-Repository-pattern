using chakito.Models;
using Microsoft.EntityFrameworkCore;

namespace chakito.repository
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<Person> persons { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Student> students { get; set; }
    }
}
