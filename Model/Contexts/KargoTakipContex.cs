using Microsoft.EntityFrameworkCore;
using Model.Entity;

namespace Model.Contexts
{
    public class KargoTakipContext : DbContext
    {
        public DbSet<SiparisUrun>? SiparisUruns { get; set; }
        public DbSet<Siparis>? Siparis { get; set; }
        public DbSet<SatisTemsilcisi>? SatisTemsilcisis { get; set; }

        public DbSet<Musteri>? Musteris { get; set; }

        public DbSet<Fatura>? Faturas { get; set; }
        public DbSet<il>? ils { get; set; }
        public DbSet<KargoFirmasi>? kargoFirmasis { get; set; }
        public DbSet<Kategori>? kategoris { get; set; }
        public DbSet<Urun>? Urun { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Datbase Bağlantımızı yapıyoruz...
            optionsBuilder.UseSqlServer("Server=.;Database=KargoTakipDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

    }
}