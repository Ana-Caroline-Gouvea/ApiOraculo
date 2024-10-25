using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IPostagemRepositorio
    {
        Task<List<PostagemCompleta>> GetAll();

        Task<PostagemCompleta> GetPostId( int id );

        Task<PostagemModel> GetById(int id);

        Task<PostagemModel> InsertPostagem(PostagemModel postagem);

        Task<PostagemModel> UpdatePostagem(PostagemModel postagem, int id);

        Task<bool> DeletePostagem(int id);
    }
}
