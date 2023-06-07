using APIDesafio.Context;
using APIDesafio.Model;
using Microsoft.EntityFrameworkCore;

namespace APIDesafio.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        public readonly TarefaContext _context;

        public TarefaRepository(TarefaContext context)
        {
            _context = context;
        }
        public async Task<Tarefa> Create(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task Delete(int id)
        {
            var tarefaDelete = await _context.Tarefas.FindAsync(id);
            _context.Tarefas.Remove(tarefaDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tarefa>> Get()
        {
           return await _context.Tarefas.ToListAsync();
        }

        public async Task<Tarefa> Get(int id)
        {
            return await _context.Tarefas.FindAsync(id);
        }

        public async Task Update(Tarefa tarefa)
        {
            _context.Entry(tarefa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
