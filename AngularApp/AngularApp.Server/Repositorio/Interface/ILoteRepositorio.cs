using AngularApp.Server.Models;
using System.Threading.Tasks;

namespace AngularApp.Server.Repositorio.Interface
{
    public interface ILoteRepositotio
    {
        Task<Lote[]> GetLotesByEventoIdAsync(int eventoId);

        Task<Lote> GetLoteByEventoId(int eventoId, int loteId);
        
    }
}
