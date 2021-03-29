using System;

namespace DojoDDD.Domain.Entidades
{
    public class Produto : IEquatable<Produto>
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public decimal Estoque { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public int ValorMinimoDeCompra { get; private set; }

        public bool Equals(Produto produto) =>
            this.Id.Equals(produto.Id) && 
            this.Estoque.Equals(produto.Estoque) &&
            this.PrecoUnitario.Equals(produto.PrecoUnitario) &&
            this.ValorMinimoDeCompra.Equals(produto.ValorMinimoDeCompra)
            && this.Descricao.Equals(produto.Descricao, StringComparison.OrdinalIgnoreCase);

        internal bool TemEstoque() =>
            Estoque > 0;

        public static Produto CriarProduto(int id, string descricao, decimal estoque, decimal precoUnitario, int valorMinimoDeCompra) =>
            new Produto
            {
                Descricao = descricao,
                Estoque = estoque,
                Id = id,
                PrecoUnitario = precoUnitario,
                ValorMinimoDeCompra = valorMinimoDeCompra
            };

    }
}