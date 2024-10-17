using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostagemController : ControllerBase
    {
        private readonly IPostagemRepositorio _postagemRepositorio;

        public PostagemController(IPostagemRepositorio postagemRepositorio)
        {
            _postagemRepositorio = postagemRepositorio;
        }

        [HttpGet("GetAllPostagem")]
        public async Task<ActionResult<List<PostagemModel>>> GetAllPostagem()
        {
            List<PostagemModel> postagem = await _postagemRepositorio.GetAll();
            return Ok(postagem);
        }

        [HttpGet("GetPostagemId/{id}")]
        public async Task<ActionResult<PostagemModel>> GetPostagemId(int id)
        {
            PostagemModel postagem = await _postagemRepositorio.GetById(id);
            return Ok(postagem);
        }

        [HttpPost("CreatePostagem")]
        public async Task<ActionResult<PostagemModel>> InsertPostagem([FromBody] PostagemModel postagemModel)
        {
            PostagemModel postagem = await _postagemRepositorio.InsertPostagem(postagemModel);
            return Ok(postagem);
        }

        [HttpPut("UpdatePostagem/{id:int}")]
        public async Task<ActionResult<PostagemModel>> UpdatePostagem(int id, [FromBody] PostagemModel postagemModel)
        {
            postagemModel.PostagemId = id;
            PostagemModel postagem = await _postagemRepositorio.UpdatePostagem(postagemModel, id);
            return Ok(postagem);
        }

        [HttpDelete("DeletePostagem/{id:int}")]
        public async Task<ActionResult<PostagemModel>> DeletePostagem(int id)
        {
            bool deleted = await _postagemRepositorio.DeletePostagem(id);
            return Ok(deleted);
        }
    }
}
