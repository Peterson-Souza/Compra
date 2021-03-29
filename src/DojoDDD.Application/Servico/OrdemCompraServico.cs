using DojoDDD.Domain;
using DojoDDD.Domain.Entidades;
using DojoDDD.Domain.Enum;
using DojoDDD.Domain.Repositorio;
using DojoDDD.Domain.Servico;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DojoDDD.Application.Servico
{
    public class OrdemCompraServico : IOrdemCompraServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        private readonly IProdutoRepositorio _produtoRepositorio;

        private readonly IOrdemCompraRepositorio _ordemCompraRepositorio;

        

        public OrdemCompraServico(IClienteRepositorio clienteRepositorio,
                                  IProdutoRepositorio produtoRepositorio,
                                  IOrdemCompraRepositorio ordemCompraRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            _produtoRepositorio = produtoRepositorio;
            _ordemCompraRepositorio = ordemCompraRepositorio;
        }

        public async Task<Result> RegistrarOrdemCompra(int clienteId, int produtoId, int quantidadeCompra)
        
        {
            var cliente = await _clienteRepositorio.ConsultarPorId(clienteId).ConfigureAwait(false);

            var produto = await _produtoRepositorio.ConsultarPorId(produtoId).ConfigureAwait(false);

            var novaOrdemDeCompra = OrdemCompra.CriarSolicitacaoOrdemDeCompra(
                                                    produto,
                                                    cliente,
                                                    quantidadeCompra);

            if (!novaOrdemDeCompra.EhValido)
                return Result<string>
                            .Fail(novaOrdemDeCompra
                                    .Notifications
                                    .Select(s => s.Message));

            var id = await _ordemCompraRepositorio.RegistrarOrdemCompra(novaOrdemDeCompra).ConfigureAwait(false);

            return Result<Guid>.Ok(id);
        }

        public async Task<Result> AlterarStatudOrdemDeCompraParaEmAnalise(Guid ordemDeCompraId)
        {
            var ordemDeCompra = await _ordemCompraRepositorio.ConsultarPorId(ordemDeCompraId).ConfigureAwait(false);

            if (ordemDeCompra is null)
                return Result.Fail("Ordem de compra não encontrada");

            try
            {
                ordemDeCompra.AlterarOrdemDeCompraParaAnalise();

                bool alterado = await _ordemCompraRepositorio
                    .AlterarOrdemDeCompra(ordemDeCompra).ConfigureAwait(false);
            }
            catch (Exception)
            {
                return Result.Fail("Erro ao alterar ordem de compra");
            }

            return Result.Ok();
        }
    }
}