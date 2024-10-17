using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Api.Repositorios
{
    public class NovidadeRepositorio :  INovidadeRepositorio
    {
        private readonly Contexto _dbContext;

        public NovidadeRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<NovidadeModel>> GetAll()
        {
            return await _dbContext.Novidade.ToListAsync();
        }

        public async Task<NovidadeModel> GetById(int id)
        {
            return await _dbContext.Novidade.FirstOrDefaultAsync(x => x.NovidadeId == id);
        }

        public async Task<NovidadeModel> InsertNovidade(NovidadeModel novidade)
        {
            await _dbContext.Novidade.AddAsync(novidade);
            await _dbContext.SaveChangesAsync();
            return novidade;
        }

        public async Task<NovidadeModel> UpdateNovidade(NovidadeModel novidade, int id)
        {
            NovidadeModel novidades = await GetById(id);
            if (novidades == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                novidades.NovidadeTexto = novidade.NovidadeTexto;
                novidades.NovidadeFoto = novidade.NovidadeFoto;
                _dbContext.Novidade.Update(novidades);
                await _dbContext.SaveChangesAsync();
            }
            return novidades;

        }

        public async Task<bool> DeleteNovidade(int id)
        {
            NovidadeModel novidades = await GetById(id);
            if (novidades == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Novidade.Remove(novidades);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
