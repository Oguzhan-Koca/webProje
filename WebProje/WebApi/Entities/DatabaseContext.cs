using Microsoft.EntityFrameworkCore;

namespace WebApi.Entities
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Urun> Urun { get; set; }
    }
}
