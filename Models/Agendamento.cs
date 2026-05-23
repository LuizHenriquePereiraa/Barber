namespace BarberTech.Models
{
    public class Agendamento
    {
        public int Id { get; set; }

        public string ClienteNome { get; set; }

        public string Servico { get; set; }

        public DateTime DataHora { get; set; }
    }
}