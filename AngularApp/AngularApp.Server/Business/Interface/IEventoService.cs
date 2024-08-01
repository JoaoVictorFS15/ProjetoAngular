using AngularApp.Server.Dtos;
using AngularApp.Server.Models;
using System.Threading.Tasks;

namespace AngularApp.Server.Business.Interface
{
    public interface IEventoService
    {
        Task<EventoDto> AddEvento(EventoDto model);
        Task<EventoDto> UpdateEvento(int id, EventoDto model);
        Task<bool> DeleteEvento(int id);

        Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante);
        Task<EventoDto[]> GetAllEventosAsync(bool incluirPalestrante);
        Task<EventoDto> GetEventosById(int id, bool incluirPalestrante);
    }
}
