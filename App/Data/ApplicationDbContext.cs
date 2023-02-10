using App.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Nota>()
                .HasOne(n => n.Categoria)
                .WithMany(c => c.Notas)
                .HasForeignKey(n => n.CategoriaId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Nota> Notas { get; set; }
    }
}