using APIDesafio.Enums;
using APIDesafio.Model;
using APIDesafio.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APIDesafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Tarefa>> GetTarefas()
        {
            return await _tarefaRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetTarefas(int id)
        {
            return await _tarefaRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Tarefa>> CreateTarefa([FromBody] Tarefa tarefa)
        {
            var novaTarefa = await _tarefaRepository.Create(tarefa);
            return CreatedAtAction(nameof(GetTarefas), new { id = novaTarefa.Id }, novaTarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTarefa(int id)
        {
            var tarefaDelete = await _tarefaRepository.Get(id);

            if(tarefaDelete == null)
                return NotFound();

            await _tarefaRepository.Delete(tarefaDelete.Id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> PutTarefa(int id, [FromBody] Tarefa tarefa)
        {
            if(id != tarefa.Id)
                return BadRequest();

            await _tarefaRepository.Update(tarefa);

            return NoContent();
        }



        //Metodos solicitados
        [HttpPost("/createJoao")]
        public async Task<ActionResult<Tarefa>> CreateTarefaJoao()
        {
            var joao = new User { Nome = "João Silva" };
            var tarefa = new Tarefa
            {
                Descricao = "Task for João",
                DtInicio = new DateTime(2021, 12, 31),
                TempoEstimado = TimeSpan.FromHours(2),
                DtFim = new DateTime(2021, 12, 31) + TimeSpan.FromHours(2),
                Status = StatusTarefa.Agendada,
                User = joao
            };
            await _tarefaRepository.Create(tarefa);
            return Ok(tarefa);
        }

        [HttpPost("/createAna")]
        public async Task<ActionResult<Tarefa>> CreateTarefaAna()
        {
            var ana = new User { Nome = "Ana Silva" };
            var tarefa = new Tarefa
            {
                Descricao = "Task for Ana",
                DtInicio = DateTime.Now,
                TempoEstimado = TimeSpan.FromHours(1),
                DtFim = DateTime.Now + TimeSpan.FromHours(1),
                Status = StatusTarefa.Agendada,
                User = ana
            };
            await _tarefaRepository.Create(tarefa);
            return Ok(tarefa);
        }

        [HttpPut("{id}/start")]
        public async Task<ActionResult> IniciaTarefa(int id)
        {
            var tarefa = await _tarefaRepository.Get(id);
            if (tarefa == null)
                return NotFound();

            tarefa.Status = StatusTarefa.EmAndamento;
            await _tarefaRepository.Update(tarefa);
            return Ok(tarefa);
        }

        [HttpPut("{id}/finish")]
        public async Task<ActionResult> TerminaTarefa(int id)
        {
            var tarefa = await _tarefaRepository.Get(id);
            if (tarefa == null)
                return NotFound();

            tarefa.Status = StatusTarefa.Finalizada;
            await _tarefaRepository.Update(tarefa);
            return Ok(tarefa);
        }
    }
}
