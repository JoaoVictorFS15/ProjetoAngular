using AngularApp.Server.Models;
using System.Threading.Tasks;

namespace AngularApp.Server.Repositorio.Interface
{
    public interface IPersitenceRepositorio
    {
        //Geral
        void Add<T>(T entity) where T : class;
        void AddRange<T>(T[] entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}
