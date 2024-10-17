using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class EventoRepositorio : IEventoRepositorio 
    {
        private readonly Contexto _dbContext;

        public EventoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EventoModel>> GetAll()
        {
            return await _dbContext.Evento.ToListAsync();
        }

        public async Task<EventoModel> GetById(int id)
        {
            return await _dbContext.Evento.FirstOrDefaultAsync(x => x.EventoId == id);
        }

        public async Task<EventoModel> InsertEvento(EventoModel eventos)
        {
            await _dbContext.Evento.AddAsync(eventos);
            await _dbContext.SaveChangesAsync();
            return eventos;
        }

        public async Task<EventoModel> UpdateEvento(EventoModel evento, int id)
        {
            EventoModel eventos = await GetById(id);
            if (eventos == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                eventos.EventoNome = eventos.EventoNome;
                eventos.EventoFoto = eventos.EventoFoto;
                _dbContext.Evento.Update(eventos);
                await _dbContext.SaveChangesAsync();
            }
            return eventos;

        }

        public async Task<bool> DeleteEvento(int id)
        {
            EventoModel eventos = await GetById(id);
            if (eventos == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Evento.Remove(eventos);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
