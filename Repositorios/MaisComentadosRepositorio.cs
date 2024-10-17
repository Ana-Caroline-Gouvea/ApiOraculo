using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Api.Repositorios
{
    public class MaisComentadosRepositorio : IMaisComentadosRepositorio
    {
        private readonly Contexto _dbContext;

        public MaisComentadosRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MaisComentadosModel>> GetAll()
        {
            return await _dbContext.MaisComentados.ToListAsync();
        }

        public async Task<MaisComentadosModel> GetById(int id)
        {
            return await _dbContext.MaisComentados.FirstOrDefaultAsync(x => x.MaisComentadosId == id);
        }

        public async Task<MaisComentadosModel> InsertMaisComentados(MaisComentadosModel maiscomentados)
        {
            await _dbContext.MaisComentados.AddAsync(maiscomentados);
            await _dbContext.SaveChangesAsync();
            return maiscomentados;
        }

        public async Task<MaisComentadosModel> UpdateMaisComentados(MaisComentadosModel maiscomentado, int id)
        {
            MaisComentadosModel maiscomentados = await GetById(id);
            if (maiscomentados == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                maiscomentados.PostagemId = maiscomentado.PostagemId;
                _dbContext.MaisComentados.Update(maiscomentados);
                await _dbContext.SaveChangesAsync();
            }
            return maiscomentados;

        }

        public async Task<bool> DeleteMaisComentados(int id)
        {
            MaisComentadosModel maiscomentados = await GetById(id);
            if (maiscomentados == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.MaisComentados.Remove(maiscomentados);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
