using AngularApp.Server.Dtos;
using System.Threading.Tasks;

namespace AngularApp.Server.Business.Interface
{
    public interface ILoteService
    {
        Task<LoteDto[]> SaveLote(int eventoId,LoteDto[] model);
        Task<bool> DeleteEvento(int eventoId, int loteId);

        Task<LoteDto[]> GetlotesByEventoIdAsync(int eventoId);
        Task<LoteDto> GetLoteById(int eventoId, int loteId);
        Task AddLote(int eventoId, LoteDto model);
    }
}
