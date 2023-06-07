using APIDesafio.Enums;

namespace APIDesafio.Model
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DtInicio { get; set; }
        public TimeSpan TempoEstimado { get; set; }
        public  StatusTarefa Status { get; set; }
        public DateTime? DtFim { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
