using DojoDDD.Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DojoDDD.Domain.Repositorio
{
    public interface IClienteRepositorio
    {
        Task<Cliente> ConsultarPorId(int id);
        Task<IEnumerable<Cliente>> ConsultarTodosCliente();
    }
}