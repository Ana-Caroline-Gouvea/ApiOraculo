using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComunidadesController : ControllerBase
    {
        private readonly IComunidadesRepositorio _comunidadesRepositorio;

        public ComunidadesController(IComunidadesRepositorio comunidadesRepositorio)
        {
            _comunidadesRepositorio = comunidadesRepositorio;
        }

        [HttpGet("GetAllComunidades")]
        public async Task<ActionResult<List<ComunidadesModel>>> GetAllComunidades()
        {
            List<ComunidadesModel> comunidades = await _comunidadesRepositorio.GetAll();
            return Ok(comunidades);
        }

        [HttpGet("GetComunidadesId/{id}")]
        public async Task<ActionResult<ComunidadesModel>> GetComunidadesId(int id)
        {
            ComunidadesModel comunidades = await _comunidadesRepositorio.GetById(id);
            return Ok(comunidades);
        }

        [HttpPost("CreateComunidades")]
        public async Task<ActionResult<ComunidadesModel>> InsertComunidades([FromBody] ComunidadesModel comunidadesModel)
        {
            ComunidadesModel comunidades = await _comunidadesRepositorio.InsertComunidades(comunidadesModel);
            return Ok(comunidades);
        }

        [HttpPut("UpdateComunidades/{id:int}")]
        public async Task<ActionResult<ComunidadesModel>> UpdateComunidades(int id, [FromBody] ComunidadesModel comunidadesModel)
        {
            comunidadesModel.ComunidadesId = id;
            ComunidadesModel comunidades = await _comunidadesRepositorio.UpdateComunidades(comunidadesModel, id);
            return Ok(comunidades);
        }

        [HttpDelete("DeleteComunidades/{id:int}")]
        public async Task<ActionResult<ComunidadesModel>> DeleteComunidades(int id)
        {
            bool deleted = await _comunidadesRepositorio.DeleteComunidades(id);
            return Ok(deleted);
        }
    }
}
