using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepositorio _eventoRepositorio;

        public EventoController(IEventoRepositorio eventoRepositorio)
        {
            _eventoRepositorio = eventoRepositorio;
        }

        [HttpGet("GetAllEvento")]
        public async Task<ActionResult<List<EventoModel>>> GetAllEvento()
        {
            List<EventoModel> evento = await _eventoRepositorio.GetAll();
            return Ok(evento);
        }

        [HttpGet("GetEventoId/{id}")]
        public async Task<ActionResult<EventoModel>> GetEventoId(int id)
        {
            EventoModel evento = await _eventoRepositorio.GetById(id);
            return Ok(evento);
        }

        [HttpPost("CreateEvento")]
        public async Task<ActionResult<EventoModel>> InsertEvento([FromBody] EventoModel eventoModel)
        {
            EventoModel evento = await _eventoRepositorio.InsertEvento(eventoModel);
            return Ok(evento);
        }

        [HttpPut("UpdateEvento/{id:int}")]
        public async Task<ActionResult<EventoModel>> UpdateEvento(int id, [FromBody] EventoModel eventoModel)
        {
            eventoModel.EventoId = id;
            EventoModel evento = await _eventoRepositorio.UpdateEvento(eventoModel, id);
            return Ok(evento);
        }

        [HttpDelete("DeleteEvento/{id:int}")]
        public async Task<ActionResult<EventoModel>> DeleteEvento(int id)
        {
            bool deleted = await _eventoRepositorio.DeleteEvento(id);
            return Ok(deleted);
        }
    }
}
