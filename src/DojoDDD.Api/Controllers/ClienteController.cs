using DojoDDD.Domain.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DojoDDD.Api.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var clientes = await _clienteRepositorio.ConsultarTodosCliente();

            if (clientes == null)
                return NoContent();

            return Ok(clientes);
        }

        [HttpGet]
        [Route("{idCliente}")]
        public async Task<IActionResult> GetById([FromRoute] int idCliente)
        {
            var clientes = await _clienteRepositorio.ConsultarPorId(idCliente).ConfigureAwait(false);

            if (clientes == null)
                return NoContent();

            return Ok(clientes);
        }
    }
}
