using System.Text.Json.Serialization;

namespace APIDesafio.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public ICollection<Tarefa> Tarefas { get; set; }
    }
}
