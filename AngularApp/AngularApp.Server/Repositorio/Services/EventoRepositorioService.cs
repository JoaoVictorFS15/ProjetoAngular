using AngularApp.Server.Data;
using AngularApp.Server.Models;
using AngularApp.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.Server.Repositorio.Services
{
    public class EventoRepositorioService : IEventoRepositorio
    {

        private readonly context _context;

        public EventoRepositorioService(context context)
        {
            _context = context;
        }

        public async Task<Evento[]> GetAllEventosAsync(bool incluirPalestrante = false)
        {
            IQueryable<Evento> query = _context.Evento
                .Include(x => x.Lote)
                .Include(x => x.RedeSocials);

            if (incluirPalestrante)
            {
                query = query.AsNoTracking().Include(x => x.PalestranteEvento).ThenInclude(x => x.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante = false)
        {
            IQueryable<Evento> query = _context.Evento
                .Include(x => x.Lote)
                .Include(x => x.RedeSocials);

            if (incluirPalestrante)
            {
                query = query.AsNoTracking().Include(x => x.PalestranteEvento).ThenInclude(x => x.Palestrante);
            }

            query = query.OrderBy(x => x.Id).Where(x => x.Tema.ToUpper().Contains(tema.ToUpper()));

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Evento> GetEventosById(int id, bool incluirPalestrante = false)
        {
            IQueryable<Evento> query = _context.Evento
                 .Include(x => x.Lote)
                 .Include(x => x.RedeSocials);

            if (incluirPalestrante)
            {
                query = query.AsNoTracking().Include(x => x.PalestranteEvento).ThenInclude(x => x.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id).Where(x => x.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
