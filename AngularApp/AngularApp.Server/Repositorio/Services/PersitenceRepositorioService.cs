using AngularApp.Server.Data;
using AngularApp.Server.Models;
using AngularApp.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.Server.Repositorio.Services
{
    public class PersitenceRepositorioService : IPersitenceRepositorio
    {
        private readonly context _context;

        public PersitenceRepositorioService(context context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void AddRange<T>(T[] entity) where T : class
        {
            _context.AddRange(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            _context.RemoveRange(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
