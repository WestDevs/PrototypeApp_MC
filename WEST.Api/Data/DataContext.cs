using Microsoft.EntityFrameworkCore;
using WEST.Api.Entities;

namespace WEST.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
                        
        }
        public DbSet<AppUser> Users { get; set; }
        
    }
}