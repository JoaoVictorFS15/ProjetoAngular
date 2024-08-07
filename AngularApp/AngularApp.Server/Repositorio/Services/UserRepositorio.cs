using AngularApp.Server.Data;
using AngularApp.Server.Models.Identity;
using AngularApp.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.Server.Repositorio.Services
{
    public class UserRepositorio : PersitenceRepositorioService, IUserRepositorio
    {
        private readonly context _context;

        public UserRepositorio(context context) : base(context)
        {
            this._context = context;
        }

        public async Task<User> GetUserByUserName(string nome)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == nome.ToLower());
        }

        public async Task<User> GetUserId(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToArrayAsync();
        }

    }
}
