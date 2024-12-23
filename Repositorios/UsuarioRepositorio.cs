﻿using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Api.Repositorios.UsuarioRepositorio;

namespace Api.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Contexto _dbContext;

        public UsuarioRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UsuarioModel>> GetAll()
        {
            return await _dbContext.Usuario.ToListAsync();
        }

        public async Task<UsuarioModel> GetById(int id)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.UsuarioId == id);
        }

        public async Task<UsuarioModel> InsertUsuario(UsuarioModel usuario)
        {
            await _dbContext.Usuario.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> UpdateUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarios = await GetById(id);
            if (usuarios == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                usuarios.UsuarioNome = usuario.UsuarioNome;
                usuarios.UsuarioFoto = usuario.UsuarioFoto;
                usuarios.UsuarioEmail = usuario.UsuarioEmail;
                usuarios.UsuarioApelido = usuario.UsuarioApelido;
                usuarios.UsuarioDataNascimento = usuario.UsuarioDataNascimento;           
                usuarios.UsuarioSenha = usuario.UsuarioSenha;
                usuarios.UsuarioConfirmarSenha = usuario.UsuarioConfirmarSenha;
                _dbContext.Usuario.Update(usuarios);
                await _dbContext.SaveChangesAsync();
            }
            return usuarios;

        }

        public async Task<bool> DeleteUsuario(int id)
        {
            UsuarioModel usuarios = await GetById(id);
            if (usuarios == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Usuario.Remove(usuarios);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioModel> LoginUsuario(string email, string senha)
        {
            UsuarioModel user = await _dbContext.Usuario.FirstOrDefaultAsync(x => x.UsuarioEmail == email && x.UsuarioSenha == senha);
            return user;
           

        }
    }

}