using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace WebApplication1.Models
{
    public class MyDbContext : DbContext

    {

        public DbSet<Door> Doors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)   // veri tabanı bağantısının nasıl yapılandırılacagını belirtir
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=dbstuden;Username=postgres;Password=riften06");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // eşleşmeler
        {
            modelBuilder.Entity<Door>().ToTable("doors");
            modelBuilder.Entity<Door>().HasKey(d => d.Id);
            modelBuilder.Entity<Door>().Property(d => d.Id).HasColumnName("id");
            modelBuilder.Entity<Door>().Property(d => d.X).HasColumnName("x");
            modelBuilder.Entity<Door>().Property(d => d.Y).HasColumnName("y");
        }

    }
}
