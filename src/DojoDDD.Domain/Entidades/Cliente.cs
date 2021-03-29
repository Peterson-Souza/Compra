using System;

namespace DojoDDD.Domain.Entidades
{
    public class Cliente : IEquatable<Cliente>
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public int Idade { get; private set; }
        public decimal Saldo { get; private set; }

        public bool Equals(Cliente cliente) =>
            this.Id.Equals(cliente.Id) &&
            this.Nome.Equals(cliente.Nome, StringComparison.OrdinalIgnoreCase) &&
            this.Endereco.Equals(cliente.Endereco, StringComparison.OrdinalIgnoreCase) &&
            this.Id.Equals(cliente.Id) &&
            this.Saldo.Equals(cliente.Saldo);

        internal bool SaldoEhSuficiente(decimal valorOperacao) =>
            Saldo >= valorOperacao;

        public static Cliente CriarCliente(int id, string nome, string endereco, int idade, decimal saldo) =>
            new Cliente
            {
                Id = id,
                Nome = nome,
                Endereco = endereco,
                Idade = idade,
                Saldo = saldo
            };
    }
}