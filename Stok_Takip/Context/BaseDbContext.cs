using Microsoft.EntityFrameworkCore;
using Stok_Takip.Models;

namespace Stok_Takip.Context
{
    public class BaseDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=MURATYıLDıZ\\MSSQLSERVER22;database=Stok_Takip;integrated security=True;TrustServerCertificate=True");

        }
        public DbSet<Urun> uruns { get; set; }
        public DbSet<Musteri> musteri { get; set; }
        public DbSet<Satis> Satis { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet <Login> logins { get; set; }
    }
}
