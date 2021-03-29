using DojoDDD.Domain.Entidades;
using DojoDDD.Domain.Enum;
using DojoDDD.Domain.Repositorio;
using DojoDDD.Infrastructure.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DojoDDD.Infrastructure.Repositorio
{
    public class OrdemCompraRepositorio : IOrdemCompraRepositorio
    {
        private readonly DataStore _dataStore;

        public OrdemCompraRepositorio(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task<bool> AlterarOrdemDeCompra(OrdemCompra ordemCompra)
        {
            var index = await GetIndexOrdemCompra(
                            await ConsultarPorId(ordemCompra.Id));

            await Task.Run(() => _dataStore.OrdensCompras[index] = ordemCompra);

            return await Task.Run(() =>
                            _dataStore
                                .OrdensCompras
                                    .Any(a => a.Equals(ordemCompra)));
        }


        public async Task<OrdemCompra> ConsultarPorId(Guid id) =>
            await Task
                    .Run(() =>
                        _dataStore
                            .OrdensCompras
                                .Find(f => id.Equals(f.Id)));

        public async Task<Guid> RegistrarOrdemCompra(OrdemCompra ordemCompra)
        {
            await Task.Run(() => _dataStore.OrdensCompras.Add(ordemCompra)).ConfigureAwait(false);

            return ordemCompra.Id;
        }



        async Task<int> GetIndexOrdemCompra(OrdemCompra ordemCompra) =>
            await Task.Run(() => 
                    _dataStore
                        .OrdensCompras
                            .IndexOf(ordemCompra));

    }
}