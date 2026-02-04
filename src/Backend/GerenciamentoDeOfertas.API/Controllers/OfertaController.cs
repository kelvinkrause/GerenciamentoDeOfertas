using GerenciamentoDeOfertas.Communication.Requests;
using GerenciamentoDeOfertas.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeOfertas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OfertaController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public IActionResult ListarOfertaPorIdAsync(int id)
        {
            return Ok($"Buscando oferta com ID: {id}");
        }

        [HttpGet]
        public IActionResult ListarTodasOfertaAsync()
        {
            return Ok($"Buscando todas ofertas.");
        }


        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegistradoOfertaJson), StatusCodes.Status201Created)]
        public IActionResult RegistrarOfertaAsync(
            [FromBody] RequestRegistrarOfertaJson request)
        {
            var response = new ResponseRegistradoOfertaJson
            {
                Nome = request.Nome,
                Descricao = request.Descricao,
                Preco = request.Preco,
                DataRegistro = request.DataRegistro
            };

            return Created(string.Empty, response);
        }

        [HttpPut("{id:int}")]
        public IActionResult AtualizarOfertaAsync(int id, [FromBody] RequestAtualizarOfertaJson request)
        {
            return Ok("Atualizando oferta.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletarOfertaAsync(int id)
        {
            return Ok("Deletando oferta.");
        }
    }
}
