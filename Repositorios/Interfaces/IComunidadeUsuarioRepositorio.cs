using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IComunidadeUsuarioRepositorio
    {
        Task<List<ComunidadeUsuarioModel>> GetAll();

        Task<ComunidadeUsuarioModel> GetById(int id);

        Task<ComunidadeUsuarioModel> InsertComunidadeUsuario(ComunidadeUsuarioModel comunidadeusuario);

        Task<ComunidadeUsuarioModel> UpdateComunidadeUsuario(ComunidadeUsuarioModel comunidadeusuario, int id);

        Task<bool> DeleteComunidadeUsuario(int id);


    }
}
