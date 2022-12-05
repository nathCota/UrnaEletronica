
using Entidades.enums;

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
        public Poderes PoderRepublica { get; set; }
        public Eleicao()
        {
            Id = Guid.NewGuid();
        }
        /*public Eleicao(string apelido, int VerificaPoder)
        {
            Id = Guid.NewGuid();
            Apelido = apelido;
            QuantidadeVotosBrancos = 0;
            QuantidadeVotosNulos = 0;
            TurnoAtual = 1;
            Vigente = false;
            switch (VerificaPoder)
            {
                case 0: PoderRepublica = Poderes.LEGISLATIVO;
                break;
                case 1: PoderRepublica= Poderes.EXECUTIVO;
                break;             
            }
        }
        */
    }
}
