using AngularApp.Server.Models.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularApp.Server.Repositorio.Interface
{
    public interface IUserRepositorio : IPersitenceRepositorio
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserId(int id);
        Task<User> GetUserByUserName(string nome);
    }
}
