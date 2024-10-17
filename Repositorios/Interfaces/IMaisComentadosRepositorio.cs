using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IMaisComentadosRepositorio
    {
        Task<List<MaisComentadosModel>> GetAll();

        Task<MaisComentadosModel> GetById(int id);

        Task<MaisComentadosModel> InsertMaisComentados(MaisComentadosModel maiscomentado);

        Task<MaisComentadosModel> UpdateMaisComentados(MaisComentadosModel maiscomentado, int id);

        Task<bool> DeleteMaisComentados(int id);
    }
}
