using AngularApp.Server.Models;
using System.Threading.Tasks;

namespace AngularApp.Server.Repositorio.Interface
{
    public interface IPalestranteRepositorio
    {
        //Palestrantes
        Task<PalestranteDto[]> GetAllPalestranteByNomeAsync(string nome, bool incluirEvento);
        Task<PalestranteDto[]> GetAllPalestrantesAsync(bool incluirEvento);
        Task<PalestranteDto> GetPalestrantById(int id, bool incluirEvento);
    }
}
