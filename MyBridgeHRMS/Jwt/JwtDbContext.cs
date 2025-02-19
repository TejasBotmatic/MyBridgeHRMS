using MyBridgeHRMS.AuthModels;
using Microsoft.EntityFrameworkCore;

namespace MyBridgeHRMS.JwtContext
{
    public class JwtDbContext : DbContext
    {
        public JwtDbContext(DbContextOptions<JwtDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
  
    }
}