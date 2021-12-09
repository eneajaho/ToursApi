using ToursApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ToursApi.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Package> Packages { get; set; } = null!;
        // public DbSet<Photo> Photos { get; set; }
    }
    
 
}
