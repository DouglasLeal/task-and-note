using App.Data;
using App.Interfaces;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<Categoria> _dbSet;

        public CategoriaRepository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = db.Set<Categoria>();
        }

        public async Task Criar(Categoria categoria)
        {
            await _dbSet.AddAsync(categoria);
            await _db.SaveChangesAsync();
        }

        public async Task<IList<Categoria>> Listar()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Categoria?> BuscarPorId(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Atualizar(Categoria categoria)
        {
            _dbSet.Update(categoria);
            await _db.SaveChangesAsync();
        }
              
        public async Task Excluir(Categoria categoria)
        {
            _dbSet.Remove(categoria);
            await _db.SaveChangesAsync();
        }        

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
