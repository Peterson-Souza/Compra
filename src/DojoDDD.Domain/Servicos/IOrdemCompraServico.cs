using System;
using System.Threading.Tasks;

namespace DojoDDD.Domain.Servico
{
    public interface IOrdemCompraServico
    {
        Task<Result> AlterarStatudOrdemDeCompraParaEmAnalise(Guid ordemDeCompraId);
        Task<Result> RegistrarOrdemCompra(int clienteId, int produtoId, int quantidadeCompra);
    }
}