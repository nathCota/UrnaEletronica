
namespace Entidades
{
    public class Eleicao
    {
        public Guid Id { get; set; }
        public string? Apelido { get; set; }
        public List<Guid>? CandidatosParticipantes { get; set; }
        public int QuantidadeVotosBrancos { get; set; }
        public int QuantidadeVotosNulos { get; set; }
        public int TurnoAtual { get; set; }
        public bool Vigente { get; set; } //definie se a presente eleição está ativa

        public Eleicao()
        {
            Id = Guid.NewGuid();
        }

    }
}
