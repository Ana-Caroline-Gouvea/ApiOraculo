using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Api.Repositorios
{
    public class ComunidadesRepositorio : IComunidadesRepositorio
    {
        private readonly Contexto _dbContext;

        public ComunidadesRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ComunidadesModel>> GetAll()
        {
            return await _dbContext.Comunidades.ToListAsync();
        }

        public async Task<ComunidadesModel> GetById(int id)
        {
            return await _dbContext.Comunidades.FirstOrDefaultAsync(x => x.ComunidadesId == id);
        }

        public async Task<ComunidadesModel> InsertComunidades(ComunidadesModel comunidades)
        {
            await _dbContext.Comunidades.AddAsync(comunidades);
            await _dbContext.SaveChangesAsync();
            return comunidades;
        }

        public async Task<ComunidadesModel> UpdateComunidades(ComunidadesModel comunidade, int id)
        {
            ComunidadesModel comunidades = await GetById(id);
            if (comunidades == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                comunidades.NomeComunidade = comunidade.NomeComunidade;
                _dbContext.Comunidades.Update(comunidades);
                await _dbContext.SaveChangesAsync();
            }
            return comunidades;

        }

        public async Task<bool> DeleteComunidades(int id)
        {
            ComunidadesModel comunidades = await GetById(id);
            if (comunidades == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Comunidades.Remove(comunidades);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
