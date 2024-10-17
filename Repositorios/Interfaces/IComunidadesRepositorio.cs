using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IComunidadesRepositorio
    {
        Task<List<ComunidadesModel>> GetAll();

        Task<ComunidadesModel> GetById(int id);

        Task<ComunidadesModel> InsertComunidades(ComunidadesModel comunidade);

        Task<ComunidadesModel> UpdateComunidades(ComunidadesModel comunidade, int id);

        Task<bool> DeleteComunidades(int id);
    }
}
