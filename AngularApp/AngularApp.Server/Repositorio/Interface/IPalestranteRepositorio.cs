using AngularApp.Server.Models;
using System.Threading.Tasks;

namespace AngularApp.Server.Repositorio.Interface
{
    public interface IPalestranteRepositorio
    {
        //Palestrantes
        Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome, bool incluirEvento);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool incluirEvento);
        Task<Palestrante> GetPalestrantById(int id, bool incluirEvento);
    }
}
