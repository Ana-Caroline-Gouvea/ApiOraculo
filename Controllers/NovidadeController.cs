using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NovidadeController : ControllerBase
    {
        private readonly INovidadeRepositorio _novidadeRepositorio;

        public NovidadeController(INovidadeRepositorio novidadeRepositorio)
        {
            _novidadeRepositorio = novidadeRepositorio;
        }

        [HttpGet("GetAllNovidade")]
        public async Task<ActionResult<List<NovidadeModel>>> GetAllNovidade()
        {
            List<NovidadeModel> novidade = await _novidadeRepositorio.GetAll();
            return Ok(novidade);
        }

        [HttpGet("GetNovidadeId/{id}")]
        public async Task<ActionResult<NovidadeModel>> GetNovidadeId(int id)
        {
            NovidadeModel novidade = await _novidadeRepositorio.GetById(id);
            return Ok(novidade);
        }

        [HttpPost("CreateNovidade")]
        public async Task<ActionResult<NovidadeModel>> InsertNovidade([FromBody] NovidadeModel novidadeModel)
        {
            NovidadeModel novidade = await _novidadeRepositorio.InsertNovidade(novidadeModel);
            return Ok(novidade);
        }

        [HttpPut("UpdateNovidade/{id:int}")]
        public async Task<ActionResult<NovidadeModel>> UpdateNovidade(int id, [FromBody] NovidadeModel novidadeModel)
        {
            novidadeModel.NovidadeId = id;
            NovidadeModel novidade = await _novidadeRepositorio.UpdateNovidade(novidadeModel, id);
            return Ok(novidade);
        }

        [HttpDelete("DeleteNovidade/{id:int}")]
        public async Task<ActionResult<NovidadeModel>> DeleteNovidade(int id)
        {
            bool deleted = await _novidadeRepositorio.DeleteNovidade(id);
            return Ok(deleted);
        }
    }
}
