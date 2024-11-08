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
        public async Task<List<PostagemCompleta>> GetAll()
        {
            var postagens = await _dbContext.Postagem
                .Join(
                    _dbContext.Usuario,
                    p => p.UsuarioId,
                    u => u.UsuarioId,
                    (p, u) => new PostagemCompleta
                    {
                        PostagemId = p.PostagemId,
                        PostagemNome = p.PostagemNome,
                        PostagemImg = p.PostagemImg,
                        CategoriaId = p.CategoriaId,
                        ComunidadesId = p.ComunidadesId,
                        Like = p.Like,
                        Compartilhamento = p.Compartilhamento,
                        Usuario = new UsuarioDto
                            {
                                UsuarioId = u.UsuarioId,
                                UsuarioNome = u.UsuarioNome,
                                UsuarioEmail = u.UsuarioEmail,
                                UsuarioFoto = u.UsuarioFoto,
                                UsuarioApelido = u.UsuarioApelido,
                            }
                    })
                .ToListAsync();

            return postagens;
        }

        public async Task<PostagemCompleta> GetPostId(int id)
        {
            var postagem = await _dbContext.Postagem
                .Join(
                    _dbContext.Usuario,
                    p => p.UsuarioId,
                    u => u.UsuarioId,
                    (p, u) => new PostagemCompleta
                    {
                        PostagemId = p.PostagemId,
                        PostagemNome = p.PostagemNome,
                        PostagemImg = p.PostagemImg,
                        CategoriaId = p.CategoriaId,
                        ComunidadesId = p.ComunidadesId,
                        Like = p.Like,
                        Compartilhamento = p.Compartilhamento,
                        Usuario = new UsuarioDto
                        {
                            UsuarioId = u.UsuarioId,
                            UsuarioNome = u.UsuarioNome,
                            UsuarioEmail = u.UsuarioEmail,
                            UsuarioFoto = u.UsuarioFoto,
                            UsuarioApelido = u.UsuarioApelido,
                        }
                    })
                .FirstOrDefaultAsync(x => x.PostagemId == id);

            return postagem;
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
                postagens.UsuarioId = postagem.UsuarioId;
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
