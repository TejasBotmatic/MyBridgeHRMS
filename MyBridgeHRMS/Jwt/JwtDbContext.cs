using MyBridgeHRMS.AuthModels;
using Microsoft.EntityFrameworkCore;
using MyBridgeHRMS.Models;

namespace MyBridgeHRMS.JwtContext
{
    public class JwtDbContext : DbContext
    {
        public JwtDbContext(DbContextOptions<JwtDbContext> options) : base(options)
        {

        }

        public DbSet<Employees> employees { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles"); // Ensure it maps to the correct table name

                entity.HasKey(r => r.Id);

                entity.Property(r => r.Name)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(r => r.GuardName)
                      .HasMaxLength(255);

                entity.Property(r => r.CreatedAt)
                      .HasColumnType("datetime");

                entity.Property(r => r.UpdatedAt)
                      .HasColumnType("datetime");

                entity.HasMany(r => r.Employees)
                      .WithOne(u => u.Role) // Assuming the User entity has a `Role` navigation property
                      .HasForeignKey(u => u.RoleId) // Assuming the User table has a `RoleId` foreign key
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

}
}