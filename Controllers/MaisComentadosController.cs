using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaisComentadosController : ControllerBase
    {
        private readonly IMaisComentadosRepositorio _maiscomentadosRepositorio;

        public MaisComentadosController(IMaisComentadosRepositorio maiscomentadosRepositorio)
        {
            _maiscomentadosRepositorio = maiscomentadosRepositorio;
        }

        [HttpGet("GetAllMaisComentados")]
        public async Task<ActionResult<List<MaisComentadosModel>>> GetAllMaisComentados()
        {
            List<MaisComentadosModel> maiscomentado = await _maiscomentadosRepositorio.GetAll();
            return Ok(maiscomentado);
        }

        [HttpGet("GetMaisComentadosId/{id}")]
        public async Task<ActionResult<MaisComentadosModel>> GetMaisComentadosId(int id)
        {
            MaisComentadosModel maiscomentado = await _maiscomentadosRepositorio.GetById(id);
            return Ok(maiscomentado);
        }

        [HttpPost("CreateMaisComentados")]
        public async Task<ActionResult<MaisComentadosModel>> InsertMaisComentados([FromBody] MaisComentadosModel maiscomentadosModel)
        {
            MaisComentadosModel maiscomentado = await _maiscomentadosRepositorio.InsertMaisComentados(maiscomentadosModel);
            return Ok(maiscomentado);
        }

        [HttpPut("UpdateMaisComentados/{id:int}")]
        public async Task<ActionResult<MaisComentadosModel>> UpdateMaisComentados(int id, [FromBody] MaisComentadosModel maiscomentadosModel)
        {
            maiscomentadosModel.MaisComentadosId = id;
            MaisComentadosModel maiscomentado = await _maiscomentadosRepositorio.UpdateMaisComentados(maiscomentadosModel, id);
            return Ok(maiscomentado);
        }

        [HttpDelete("DeleteMaisComentados/{id:int}")]
        public async Task<ActionResult<MaisComentadosModel>> DeleteMaisComentados(int id)
        {
            bool deleted = await _maiscomentadosRepositorio.DeleteMaisComentados(id);
            return Ok(deleted);
        }
    }
}
