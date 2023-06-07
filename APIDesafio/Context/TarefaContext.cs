using APIDesafio.Model;
using Microsoft.EntityFrameworkCore;

namespace APIDesafio.Context
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
