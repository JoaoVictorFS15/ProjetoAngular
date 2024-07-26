using AngularApp.Server.Models;
using System.Threading.Tasks;

namespace AngularApp.Server.Business.Interface
{
    public interface IEventoService
    {
        Task<Evento> AddEvento(Evento model);
        Task<Evento> UpdateEvento(int id, Evento model);
        Task<bool> DeleteEvento(int id);

        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante);
        Task<Evento[]> GetAllEventosAsync(bool incluirPalestrante);
        Task<Evento> GetEventosById(int id, bool incluirPalestrante);
    }
}
