using Entidades.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Candidato: Pessoa
    {
        public Guid Partido { get; set; }
        public int QuantidadeVotos { get; set; }
        public Poderes PoderRepublica { get; set; }
        public Cargo CardgoCandidato { get; set; }

    }
}
