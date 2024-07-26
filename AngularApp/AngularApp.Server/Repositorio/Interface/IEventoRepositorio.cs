using AngularApp.Server.Models;
using System.Threading.Tasks;

namespace AngularApp.Server.Repositorio.Interface
{
    public interface IEventoRepositorio
    {
        //Evento
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante);
        Task<Evento[]> GetAllEventosAsync(bool incluirPalestrante);
        Task<Evento> GetEventosById(int id, bool incluirPalestrante);
    }
}
