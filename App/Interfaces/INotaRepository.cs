﻿using App.Models;

namespace App.Interfaces
{
    public interface INotaRepository : IDisposable
    {
        Task Criar(Nota nota);
        Task<Nota> BuscarPorId(int id);
        Task<IList<Nota>> Listar();
        Task Atualizar(Nota nota);
        Task Excluir(Nota nota);
    }
}