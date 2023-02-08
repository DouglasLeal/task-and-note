using App.Data;
using App.Interfaces;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<Tarefa> _dbSet;

        public TarefaRepository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = db.Set<Tarefa>();
        }

        public async Task Criar(Tarefa tarefa)
        {
            await _dbSet.AddAsync(tarefa);
            await _db.SaveChangesAsync();
        }

        public async Task<IList<Tarefa>> Listar()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Tarefa?> BuscarPorId(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Atualizar(Tarefa tarefa)
        {
            _dbSet.Update(tarefa);
            await _db.SaveChangesAsync();
        }   

        public async Task Excluir(Tarefa tarefa)
        {
            _dbSet.Remove(tarefa);
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
