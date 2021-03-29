using DojoDDD.Domain.Entidades;
using DojoDDD.Domain.Enum;
using System;
using System.Threading.Tasks;

namespace DojoDDD.Domain.Repositorio
{
    public interface IOrdemCompraRepositorio
    {
        Task<Guid> RegistrarOrdemCompra(OrdemCompra ordemCompra);

        Task<OrdemCompra> ConsultarPorId(Guid id);

        Task<bool> AlterarOrdemDeCompra(OrdemCompra ordemDeCompra);
    }
}