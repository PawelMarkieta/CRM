using Microsoft.EntityFrameworkCore;
using CRMCallCenter.Models.Uzytkownicy;
using CRMCallCenter.Models.Klienci;
using CRMCallCenter.Models.Transakcje;


namespace CRMCallCenter.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        {
        }

        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Rola> Role {  get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Transakcja> Tansakcje { get; set; }
        public DbSet<Zespol> Zespoly { get; set; }
        public DbSet<PolaczenieTelefoniczne> PolaczeniaTelefoniczne { get; set; }
        public DbSet<Produkt> Produkty {  get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Uzytkownik>()
                .HasOne(u => u.Przelozony)
                .WithMany(p => p.Podwladni)
                .HasForeignKey(u => u.PrzelozonyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
