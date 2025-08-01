using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using EmployeeAPI.Models;

namespace EmployeeAPI.Data
{
    public class EmployeeDbContext : IdentityDbContext<IdentityUser>
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// DbSet for Employee entities
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Employee entity
            modelBuilder.Entity<Employee>(entity =>
            {
                // Primary key configuration (though EF Core will auto-detect this)
                entity.HasKey(e => e.EmployeeId);

                // Configure auto-increment for EmployeeId
                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedOnAdd();

                // Configure string properties with max lengths
                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20);

                entity.Property(e => e.HireDate)
                    .IsRequired();

                // Add unique constraint on Email
                entity.HasIndex(e => e.Email)
                    .IsUnique();
            });
        }
    }
}
