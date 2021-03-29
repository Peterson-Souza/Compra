using DojoDDD.Domain.Entidades;
using DojoDDD.Domain.Repositorio;
using DojoDDD.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DojoDDD.Infrastructure.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly DataStore _dataStore;

        public ClienteRepositorio(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task<Cliente> ConsultarPorId(int id)
        {
            var cliente = _dataStore.Clientes.Find(x => x.Id.Equals(id));
            return await Task.Run(() => cliente).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Cliente>> ConsultarTodosCliente() 
            => await Task.Run(() => _dataStore.Clientes).ConfigureAwait(false);
    }
}