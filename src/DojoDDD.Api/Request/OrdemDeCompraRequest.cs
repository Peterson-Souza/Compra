using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DojoDDD.Api.Request
{
    public class OrdemDeCompraRequest
    {
        public int ClienteId { get; set; }

        public int ProdutoId { get; set; }

        public int QuantidadeSolicitada { get; set; }
    }
}
