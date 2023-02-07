using App.Models;

namespace App.Interfaces
{
    public interface ITarefaRepository : IDisposable
    {
        Task Criar(Tarefa tarefa);
        Task<Tarefa> BuscarPorId(int id);
        Task<IList<Tarefa>> Listar();
        Task Atualizar(Tarefa tarefa);
        Task Excluir(Tarefa tarefa);
    }
}
