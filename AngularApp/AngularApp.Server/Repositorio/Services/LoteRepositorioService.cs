using AngularApp.Server.Data;
using AngularApp.Server.Models;
using AngularApp.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.Server.Repositorio.Services
{
    public class LoteRepositorioService : ILoteRepositotio
    {

        private readonly context _context;

        public LoteRepositorioService(context context)
        {
            _context = context;
        }

        public async Task<Lote> GetLoteByEventoId(int eventoId, int loteId)
        {
            IQueryable<Lote> query = _context.Lote;

            query = query.AsNoTracking().Where(x => x.Id == loteId && x.EventoId == eventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Lote[]> GetLotesByEventoIdAsync(int eventoId)
        {
            IQueryable<Lote> query = _context.Lote;

            query = query.AsNoTracking().Where(x => x.EventoId == eventoId);

            return await query.ToArrayAsync();
        }
    }
}
