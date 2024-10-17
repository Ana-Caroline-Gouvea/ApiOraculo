using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IEventoRepositorio
    {
        Task<List<EventoModel>> GetAll();

        Task<EventoModel> GetById(int id);

        Task<EventoModel> InsertEvento(EventoModel evento);

        Task<EventoModel> UpdateEvento(EventoModel evento, int id);

        Task<bool> DeleteEvento(int id);
    }
}
