using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Api.Repositorios
{
    public class PostagemRepositorio : IPostagemRepositorio
    {
        private readonly Contexto _dbContext;

        public PostagemRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PostagemModel>> GetAll()
        {
            return await _dbContext.Postagem.ToListAsync();
        }

        public async Task<PostagemModel> GetById(int id)
        {
            return await _dbContext.Postagem.FirstOrDefaultAsync(x => x.PostagemId == id);
        }

        public async Task<PostagemModel> InsertPostagem(PostagemModel postagem)
        {
            await _dbContext.Postagem.AddAsync(postagem);
            await _dbContext.SaveChangesAsync();
            return postagem;
        }

        public async Task<PostagemModel> UpdatePostagem(PostagemModel postagem, int id)
        {
            PostagemModel postagens = await GetById(id);
            if (postagens == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                postagens.PostagemNome = postagem.PostagemNome;
                postagens.PostagemImg = postagem.PostagemImg;
                postagens.CategoriaId = postagem.CategoriaId;
                postagens.ComunidadesId = postagem.ComunidadesId;
                postagens.Like = postagem.Like;
                postagens.Compartilhamento = postagem.Compartilhamento;
                _dbContext.Postagem.Update(postagens);
                await _dbContext.SaveChangesAsync();
            }
            return postagens;

        }

        public async Task<bool> DeletePostagem(int id)
        {
            PostagemModel postagens = await GetById(id);
            if (postagens == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Postagem.Remove(postagens);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
