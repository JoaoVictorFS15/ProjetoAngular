using AngularApp.Server.Business.Interface;
using AngularApp.Server.Models;
using AngularApp.Server.Repositorio.Interface;
using System;
using System.Threading.Tasks;

namespace AngularApp.Server.Business.Service
{
    public class EventoService : IEventoService, IEventoRepositorio
    {

        private readonly IPersitenceRepositorio _persitenceRepositorio;
        private readonly IEventoRepositorio _eventoRepositorio;

        public EventoService(IPersitenceRepositorio persitenceRepositorio, IEventoRepositorio eventoRepositorio)
        {
            _eventoRepositorio = eventoRepositorio;
            _persitenceRepositorio = persitenceRepositorio;
        }
        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _persitenceRepositorio.Add(model);

                if (await _persitenceRepositorio.SaveChangesAsync())
                {
                    return await _eventoRepositorio.GetEventosById(model.Id, false);
                }
                return null;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public async Task<bool> DeleteEvento(int id)
        {
            try
            {
                var evento = await _eventoRepositorio.GetEventosById(id, false);
                if (evento == null) throw new Exception ("Evento não encontrado.");

                _persitenceRepositorio.Delete(evento);

                return await _persitenceRepositorio.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Evento> UpdateEvento(int id, Evento model)
        {
            try
            {
                var evento = await _eventoRepositorio.GetEventosById(id, false);
                if (evento == null) return null;

                model.Id = evento.Id;

                _persitenceRepositorio.Update(model);

                if (await _persitenceRepositorio.SaveChangesAsync())
                {
                    return await _eventoRepositorio.GetEventosById(model.Id, false);
                }
                return null;
            }
            catch (Exception e) {
            
                throw new Exception(e.Message);
            
            }
        }


        public async Task<Evento[]> GetAllEventosAsync(bool incluirPalestrante = false)
        {
            try
            {
                var eventos = await _eventoRepositorio.GetAllEventosAsync(incluirPalestrante);

                if (eventos == null) return null;
                return eventos;
            }
            catch (Exception e) 
            { 
                throw new Exception(e.Message); 
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante = false)
        {
            try
            {
                var eventos = await _eventoRepositorio.GetAllEventosByTemaAsync(tema, incluirPalestrante);

                if (eventos == null) return null;
                return eventos;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Evento> GetEventosById(int id, bool incluirPalestrante = false)
        {
            try
            {
                var eventos = await _eventoRepositorio.GetEventosById(id, incluirPalestrante);

                if (eventos == null) return null;
                return eventos;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
