using AuthNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthNetCore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        
    }
}