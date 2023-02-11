using App.Data;
using App.Interfaces;
using App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<Nota> _dbSet;

        public NotaRepository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = db.Set<Nota>();
        }

        public async Task Criar(Nota nota)
        {
            await _dbSet.AddAsync(nota);
            await _db.SaveChangesAsync();
        }

        public async Task<IList<Nota>> Listar(string usuarioId)
        {
            return await _dbSet.Where(n => n.AspNetUserId == usuarioId).Include(n => n.Categoria).ToListAsync();
        }

        public async Task<Nota?> BuscarPorId(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Atualizar(Nota nota)
        {
            _dbSet.Update(nota);
            await _db.SaveChangesAsync();
        }       

        public async Task Excluir(Nota nota)
        {
            _dbSet.Remove(nota);
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
