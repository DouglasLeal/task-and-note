using App.Models;

namespace App.Interfaces
{
    public interface ICategoriaRepository : IDisposable
    {
        Task Criar(Categoria categoria);
        Task<Categoria> BuscarPorId(int id);
        Task<IList<Categoria>> Listar(string usuarioId);
        Task Atualizar(Categoria categoria);
        Task Excluir(Categoria categoria);
    }
}
