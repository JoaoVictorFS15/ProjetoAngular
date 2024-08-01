using AngularApp.Server.Data;
using AngularApp.Server.Models;
using AngularApp.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.Server.Repositorio.Services
{
    public class PalestranteRepositorioService : IPalestranteRepositorio
    {

        private readonly context _context;

        public PalestranteRepositorioService(context context)
        {
            _context = context;
        }
        public async Task<PalestranteDto[]> GetAllPalestranteByNomeAsync(string nome, bool incluirEvento = false)
        {
            IQueryable<PalestranteDto> query = _context.Palestrante
               .Include(x => x.RedesSocials);

            if (incluirEvento)
            {
                query = query.AsNoTracking().Include(x => x.PalestranteEvento).ThenInclude(x => x.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id).Where(x => x.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<PalestranteDto[]> GetAllPalestrantesAsync(bool incluirEvento = false)
        {
            IQueryable<PalestranteDto> query = _context.Palestrante
               .Include(x => x.RedesSocials);

            if (incluirEvento)
            {
                query = query.AsNoTracking().Include(x => x.PalestranteEvento).ThenInclude(x => x.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }


        public async Task<PalestranteDto> GetPalestrantById(int id, bool incluirEvento = false)
        {
            IQueryable<PalestranteDto> query = _context.Palestrante
                .Include(x => x.RedesSocials);

            if (incluirEvento)
            {
                query = query.AsNoTracking().Include(x => x.PalestranteEvento).ThenInclude(x => x.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id).Where(x => x.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
