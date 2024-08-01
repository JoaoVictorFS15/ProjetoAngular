using AngularApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularApp.Server.Data
{
    public class context : DbContext
    {
        public context(DbContextOptions<context> options) : base(options) { }

        public DbSet<Evento> Evento { get; set; }
        public DbSet<PalestranteEvento> PalestranteEvento { get; set; }
        public DbSet<PalestranteDto> Palestrante { get; set; }
        public DbSet<Lote> Lote { get; set; }
        public DbSet<RedeSocial> RedeSocial { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>().HasKey(x => new { x.PalestranteId, x.EventoId });

            modelBuilder.Entity<Lote>().Property(l => l.Preco).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Evento>().HasMany(x => x.RedeSocials).WithOne( x=> x.Evento).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PalestranteDto>().HasMany(x => x.RedesSocials).WithOne( x=> x.palestrante).OnDelete(DeleteBehavior.Cascade);
        }


    }
}
