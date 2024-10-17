using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface INovidadeRepositorio
    {
        Task<List<NovidadeModel>> GetAll();

        Task<NovidadeModel> GetById(int id);

        Task<NovidadeModel> InsertNovidade(NovidadeModel novidade);

        Task<NovidadeModel> UpdateNovidade(NovidadeModel novidade, int id);

        Task<bool> DeleteNovidade(int id);
    }
}
