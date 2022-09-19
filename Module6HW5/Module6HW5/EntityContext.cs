using Microsoft.EntityFrameworkCore;
using Module6HW5.Entity;

namespace Module6HW5
{
    public class EntityContext : DbContext
    {
        public DbSet<Users> Users { get; set; }

        public DbSet<RoleUsers> RoleUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-EP3R97J;Initial Catalog=Module6HW5.Test;Integrated Security=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Users>()
                .ToTable("Users")
                .HasKey(k => k.Id);

            modelBuilder.Entity<Users>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Users>()
                .Property(p => p.Password)
                .IsRequired();


            modelBuilder.Entity<RoleUsers>()
                .ToTable("RoleUsers")
                .HasKey(k => k.RoleId);

            modelBuilder.Entity<RoleUsers>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
