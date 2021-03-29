using DojoDDD.Domain.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace DojoDDD.Domain.Entidades
{
    public class OrdemCompra : EntidadeBase, IEquatable<OrdemCompra>
    {
        OrdemCompra()
        {
            Status = OrdemCompraStatus.Solicitado;
        }

        public Guid Id { get; } = Guid.NewGuid();

        public DateTime DataOperacao { get; private set; }

        public Produto Produto { get; private set; }

        public Cliente Cliente { get; private set; }

        public int QuantidadeSolicitada { get; private set; }

        public decimal ValorOperacao { get; private set; }

        public OrdemCompraStatus Status { get; private set; }

        bool SolicitacaoDeCompraEhValida()
        {
            var contract  = new Contract<OrdemCompra>()
                .IsTrue(QuantidadeSolicitada > 0, nameof(QuantidadeSolicitada), "Quantidade solicitada não suficiente para compra.")
                .IsTrue(Produto.TemEstoque(), "Estoque", "Quantidade em estoque não suficiente para compra.")
                .IsTrue(Cliente.SaldoEhSuficiente(ValorOperacao), "Saldo", "Cliente não possui saldo suficiente para compra.")
                .IsTrue(ValorOperacao < Produto.ValorMinimoDeCompra, "Quantidade", "Quantidade mínima não atendida para compra.")
                .IsTrue(ValorOperacao > Produto.Estoque, "Estoque", "Quantidade em estoque não suficiente para compra.");

            base.AddNotifications(contract.Notifications);

            return EhValido;
        }

        public bool Equals(OrdemCompra ordemCompra) =>
            this.Cliente.Equals(ordemCompra.Cliente) &&
            this.DataOperacao.Equals(ordemCompra.DataOperacao) &&
            this.EhValido.Equals(ordemCompra.EhValido) &&
            this.Id.Equals(ordemCompra.Id) &&
            this.Produto.Equals(ordemCompra.Produto) &&
            this.QuantidadeSolicitada.Equals(ordemCompra.QuantidadeSolicitada) &&
            this.ValorOperacao.Equals(ordemCompra.ValorOperacao) &&
            this.Status.Equals(ordemCompra.Status);



        public void AlterarOrdemDeCompraParaAnalise() =>
            Status = OrdemCompraStatus.EmAnalise;

        public static OrdemCompra CriarSolicitacaoOrdemDeCompra(Produto produto, Cliente cliente, int quantidadeSolicitada)
        {
            var ordemCompra = new OrdemCompra
            {
                Cliente = cliente,
                Produto = produto,
                DataOperacao = DateTime.Now,
                QuantidadeSolicitada = quantidadeSolicitada,
                ValorOperacao = Math.Round(produto.PrecoUnitario * quantidadeSolicitada, 2)
            };

            ordemCompra.SolicitacaoDeCompraEhValida();

            return ordemCompra;
        }
    }
}