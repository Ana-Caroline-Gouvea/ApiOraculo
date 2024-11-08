using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComunidadeUsuarioController : ControllerBase
    {
        private readonly IComunidadeUsuarioRepositorio _comunidadeusuarioRepositorio;

        public ComunidadeUsuarioController(IComunidadeUsuarioRepositorio comunidadeusuarioRepositorio)
        {
            _comunidadeusuarioRepositorio = comunidadeusuarioRepositorio;
        }

        [HttpGet("GetAllComunidadeUsuario")]
        public async Task<ActionResult<List<ComunidadeUsuarioModel>>> GetAllComunidadeUsuario()
        {
            List<ComunidadeUsuarioModel> comunidadeusuario = await _comunidadeusuarioRepositorio.GetAll();
            return Ok(comunidadeusuario);
        }

        [HttpGet("GetComunidadeUsuarioId/{id}")]
        public async Task<ActionResult<ComunidadeUsuarioModel>> GetComunidadeUsuarioId(int id)
        {
            ComunidadeUsuarioModel comunidadeusuario = await _comunidadeusuarioRepositorio.GetById(id);
            return Ok(comunidadeusuario);
        }

        [HttpPost("CreateComunidadeUsuario")]
        public async Task<ActionResult<ComunidadeUsuarioModel>> InsertComunidadeUsuario([FromBody] ComunidadeUsuarioModel comunidadeusuarioModel)
        {
            ComunidadeUsuarioModel comunidadeusuario = await _comunidadeusuarioRepositorio.InsertComunidadeUsuario(comunidadeusuarioModel);
            return Ok(comunidadeusuario);
        }

        [HttpPut("UpdateComunidadeUsuario/{id:int}")]
        public async Task<ActionResult<ComunidadeUsuarioModel>> UpdateComunidadeUsuario(int id, [FromBody] ComunidadeUsuarioModel comunidadeusuarioModel)
        {
            comunidadeusuarioModel.ComunidadeUsuarioId = id;
            ComunidadeUsuarioModel comunidadeusuario = await _comunidadeusuarioRepositorio.UpdateComunidadeUsuario(comunidadeusuarioModel, id);
            return Ok(comunidadeusuario);
        }

        [HttpDelete("DeleteComunidadeUsuario/{id:int}")]
        public async Task<ActionResult<ComunidadeUsuarioModel>> DeleteComunidadeUsuario(int id)
        {
            bool deleted = await _comunidadeusuarioRepositorio.DeleteComunidadeUsuario(id);
            return Ok(deleted);
        }
    }
}
