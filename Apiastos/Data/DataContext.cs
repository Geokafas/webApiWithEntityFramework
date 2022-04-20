using Microsoft.EntityFrameworkCore;

namespace Apiastos.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Supermoufa> Supermoufas { get; set; }
    }
}
