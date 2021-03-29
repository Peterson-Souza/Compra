﻿using DojoDDD.Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DojoDDD.Domain.Repositorio
{
    public interface IProdutoRepositorio
    {
        Task<Produto> ConsultarPorId(int id);
        Task<IEnumerable<Produto>> Consultar();
    }
}