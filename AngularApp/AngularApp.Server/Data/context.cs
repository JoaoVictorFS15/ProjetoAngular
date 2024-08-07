using AngularApp.Server.Models;
using AngularApp.Server.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AngularApp.Server.Data
{
    public class context : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public context(DbContextOptions<context> options) : base(options) { }

        public DbSet<Evento> Evento { get; set; }
        public DbSet<PalestranteEvento> PalestranteEvento { get; set; }
        public DbSet<Palestrante> Palestrante { get; set; }
        public DbSet<Lote> Lote { get; set; }
        public DbSet<RedeSocial> RedeSocial { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(x =>
            {
                x.HasKey(i => new { i.UserId, i.RoleId });

                x.HasOne(f => f.Role).WithMany(a => a.userRoles).HasForeignKey(z => z.RoleId).IsRequired();
                x.HasOne(f => f.
                User).WithMany(a => a.UserRoles).HasForeignKey(z => z.UserId).IsRequired();

            });
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(x => new { x.PalestranteId, x.EventoId });

            modelBuilder.Entity<Lote>().
                Property(l => l.Preco)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Evento>()
                .HasMany(x => x.RedeSocials)
                .WithOne(x => x.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
                .HasMany(x => x.RedesSocials)
                .WithOne(x => x.palestrante)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Lote>()
                .HasOne(l => l.Evento)
                .WithMany(e => e.Lote)
                .HasForeignKey(l => l.EventoId);

            modelBuilder.Entity<Palestrante>()
                .HasOne(p => p.User)
                .WithMany(u => u.Palestrantes) // Add this navigation property
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

        }


    }
}
