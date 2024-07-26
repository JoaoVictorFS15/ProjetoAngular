using CursoAngular.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoAngular.Data
{
    public class context : DbContext
    {
        public context(DbContextOptions<context> options) : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }
    }
}