using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class ComunidadeUsuarioRepositorio : IComunidadeUsuarioRepositorio
    {
         private readonly Contexto _dbContext;

    public ComunidadeUsuarioRepositorio(Contexto dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ComunidadeUsuarioModel>> GetAll()
    {
        return await _dbContext.ComunidadeUsuario.ToListAsync();
    }

        public async Task<ComunidadeUsuarioModel> GetById(int id)
        {
            return await _dbContext.ComunidadeUsuario.FirstOrDefaultAsync(x => x.ComunidadeUsuarioId == id);
        }

        public async Task<ComunidadeUsuarioModel> InsertComunidadeUsuario(ComunidadeUsuarioModel comunidadeusuario)
        {
            await _dbContext.ComunidadeUsuario.AddAsync(comunidadeusuario);
            await _dbContext.SaveChangesAsync();
            return comunidadeusuario;
        }

        public async Task<ComunidadeUsuarioModel> UpdateComunidadeUsuario(ComunidadeUsuarioModel comunidadeusuario, int id)
        {
            ComunidadeUsuarioModel comunidadeusuarios = await GetById(id);
            if (comunidadeusuario == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                comunidadeusuarios.UsuarioId = comunidadeusuario.UsuarioId;
                comunidadeusuarios.ComunidadesId = comunidadeusuario.ComunidadesId;
                _dbContext.ComunidadeUsuario.Update(comunidadeusuarios);
                await _dbContext.SaveChangesAsync();
            }
            return comunidadeusuarios;

        }

        public async Task<bool> DeleteComunidadeUsuario(int id)
        {
            ComunidadeUsuarioModel comunidadeusuarios = await GetById(id);
            if (comunidadeusuarios == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.ComunidadeUsuario.Remove(comunidadeusuarios);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
