using AngularApp.Server.Business.Interface;
using AngularApp.Server.Dtos;
using AngularApp.Server.Models;
using AngularApp.Server.Repositorio.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularApp.Server.Business.Service
{
    public class EventoService : IEventoService
    {

        private readonly IPersitenceRepositorio _persitenceRepositorio;
        private readonly IEventoRepositorio _eventoRepositorio;
        private readonly IMapper _mapper;

        public EventoService(IPersitenceRepositorio persitenceRepositorio, IEventoRepositorio eventoRepositorio, IMapper mapper)
        {
            _eventoRepositorio = eventoRepositorio;
            _persitenceRepositorio = persitenceRepositorio;
            _mapper = mapper;

        }
        public async Task<EventoDto> AddEvento(EventoDto model)
        {
            try
            {
                var retorno = _mapper.Map<Evento>(model); 

                _persitenceRepositorio.Add<Evento>(retorno);

                if (await _persitenceRepositorio.SaveChangesAsync())
                {
                    var eve = await _eventoRepositorio.GetEventosById(retorno.Id, false);

                    return _mapper.Map<EventoDto>(eve);
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
        public async Task<EventoDto> UpdateEvento(int id, EventoDto model)
        {
            try
            {
                var evento = await _eventoRepositorio.GetEventosById(id, false);
                if (evento == null) return null;

                var retorno = _mapper.Map<Evento>(model);

                retorno.Id = evento.Id;

                _persitenceRepositorio.Update(retorno);

                if (await _persitenceRepositorio.SaveChangesAsync())
                {
                    var eve = await _eventoRepositorio.GetEventosById(retorno.Id, false);

                    return _mapper.Map<EventoDto>(eve);
                }
                return null;
            }
            catch (Exception e) {
            
                throw new Exception(e.Message);
            
            }
        }

        public async Task<EventoDto[]> GetAllEventosAsync(bool incluirPalestrante = false)
        {
            try
            {
                var eventos = await _eventoRepositorio.GetAllEventosAsync(incluirPalestrante);

                if (eventos == null) return null;
                
                var retorno = _mapper.Map<EventoDto[]>(eventos);
                return retorno;
            }
            catch (Exception e) 
            { 
                throw new Exception(e.Message); 
            }
        }

        public async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante = false)
        {
            try
            {
                var eventos = await _eventoRepositorio.GetAllEventosByTemaAsync(tema, incluirPalestrante);

                if (eventos == null) return null;

                var  retorno = _mapper.Map<EventoDto[]>(eventos);
                return retorno;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<EventoDto> GetEventosById(int id, bool incluirPalestrante = false)
        {
            try
            {
                var eventos = await _eventoRepositorio.GetEventosById(id, incluirPalestrante);

                if (eventos == null) return null;


                var retorno = _mapper.Map<EventoDto>(eventos);
                return retorno;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
