using Microsoft.EntityFrameworkCore;

namespace PersonelTayin.Models
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Personel> Personeller { get; set; }
        public DbSet<TayinTalebi> TayinTalepleri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Personel → TayinTalepleri ilişkisi
            modelBuilder.Entity<TayinTalebi>()
                .HasOne(t => t.Personel)
                .WithMany(p => p.TayinTalepleri)
                .HasForeignKey(t => t.PersonelId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
