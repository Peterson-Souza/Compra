using DojoDDD.Api.Request;
using DojoDDD.Domain.Entidades;
using DojoDDD.Domain.Repositorio;
using DojoDDD.Domain.Servico;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DojoDDD.Api.Controllers
{
    [ApiController]
    [Route("ordemcompra")]
    public class OrdemCompraController : Controller
    {
        private readonly IOrdemCompraServico _ordemCompraServico;
        private readonly IOrdemCompraRepositorio _ordemCompraRepositorio;

        public OrdemCompraController(IOrdemCompraServico ordemCompraServico, IOrdemCompraRepositorio ordemCompraRepositorio)
        {
            _ordemCompraServico = ordemCompraServico;
            _ordemCompraRepositorio = ordemCompraRepositorio;
        }

        [HttpGet]
        [Route("{idOrdemCompra}")]
        public async Task<IActionResult> ConsultarPorId([FromRoute] Guid idOrdemCompra)
        {
            var result = await _ordemCompraRepositorio.ConsultarPorId(idOrdemCompra);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrdemDeCompraRequest ordemCompra)
        {
            var result = await _ordemCompraServico.RegistrarOrdemCompra(ordemCompra.ClienteId, ordemCompra.ProdutoId, ordemCompra.QuantidadeSolicitada);

            if (result.IsSuccess())
                return Created(string.Empty, result);

            return BadRequest(result.Messages);
        }
    }
}
