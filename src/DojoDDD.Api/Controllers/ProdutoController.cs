using DojoDDD.Domain.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DojoDDD.Api.Controllers
{
    [ApiController]
    [Route("produtos")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var clientes = await _produtoRepositorio.Consultar();
            if (clientes == null)
                return NoContent();

            return Ok(clientes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var clientes = await _produtoRepositorio.ConsultarPorId(
                id).ConfigureAwait(false);

            if (clientes == null)
                return NoContent();

            return Ok(clientes);
        }
    }
}
