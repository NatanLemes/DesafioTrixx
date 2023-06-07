using APIDesafio.Model;

namespace APIDesafio.Repositories
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> Get();

        Task<Tarefa> Get(int id);

        Task<Tarefa> Create(Tarefa tarefa);

        Task Update(Tarefa tarefa);

        Task Delete(int id);

    }
}
